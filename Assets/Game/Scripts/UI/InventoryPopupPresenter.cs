using System.Collections.Generic;
using Modules.Inventories;
using SampleGame.Gameplay;
using Sirenix.OdinInspector;

namespace Game.Scripts.UI
{
    public sealed class InventoryPopupPresenter
    {
        private readonly InventoryPopupView _inventoryView;
        private readonly Inventory<Item> _inventory;
        private readonly ItemCardPresenter.Factory _itemFactory;
        
        private readonly Dictionary<Item, ItemCardPresenter> _cards = new();
        
        public InventoryPopupPresenter(
            InventoryPopupView inventoryView, 
            Inventory<Item> inventory, 
            ItemCardPresenter.Factory itemFactory)
        {
            _inventoryView = inventoryView;
            _inventory = inventory;
            _itemFactory = itemFactory;
        }
        
        [Button]
        public void Show()
        {
            _inventoryView.Show();
            _inventoryView.OnClosedClicked += OnCloseClicked;

            _inventory.OnCellAdded += OnItemAdded;
            _inventory.OnCellRemoved += OnItemRemoved;
            
            foreach (KeyValuePair<Item, int> pair in _inventory.GetItems()) 
                CreateCard(pair.Key);
        }

        [Button]
        public void Hide()
        {
            _inventoryView.Hide();
            _inventoryView.OnClosedClicked -= OnCloseClicked;
            
            _inventory.OnCellAdded -= OnItemAdded;
            _inventory.OnCellRemoved -= OnItemRemoved;
            
            foreach (KeyValuePair<Item, ItemCardPresenter> pair in _cards)
            {
                ItemCardPresenter presenter = pair.Value;
                ItemCardView view = presenter.View;
                _inventoryView.DespawnItem(view);
                presenter.Dispose();
            }
            
            _cards.Clear();
        }

        private void OnItemAdded(Item item, int count)
        {
            CreateCard(item);
        }

        private void OnItemRemoved(Item item)
        {
            if (_cards.Remove(item, out ItemCardPresenter presenter))
            {
                ItemCardView view = presenter.View;
                _inventoryView.DespawnItem(view);
                presenter.Dispose();
            }
        }

        private void CreateCard(Item item)
        {
            ItemCardView cardView = _inventoryView.SpawnItem();
            ItemCardPresenter cardPresenter = _itemFactory.Create(item, cardView);
            _cards.Add(item, cardPresenter);
        }

        private void OnCloseClicked() => Hide();
    }
}