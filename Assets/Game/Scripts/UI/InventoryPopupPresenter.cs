using System.Collections.Generic;
using Modules.Inventories;
using Modules.Popups;
using SampleGame.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class InventoryPopupPresenter : PopupPresenter<InventoryPopupPresenter.Args>
    {

        public struct Args : IPopupArgs
        {
            public bool animateShow;
        }
        
        [SerializeField] private InventoryPopupView _inventoryView;
        [SerializeField] private Transform _container;
        
        private Inventory<Item> _inventory;
        private ItemCardPresenter.Pool _cardPresenterPool;
        
        private readonly Dictionary<Item, ItemCardPresenter> _cards = new();
        
        [Inject]
        public void Construct(Inventory<Item> inventory, ItemCardPresenter.Pool itemPool)
        {
            _inventory = inventory;
            _cardPresenterPool = itemPool;
        }
        
        [Button]
        public override void Show(Args args)
        {
            if (args.animateShow) 
                _inventoryView.AnimateShow();
            else
                _inventoryView.Show();

            _inventoryView.OnClosedClicked += OnCloseClicked;

            _inventory.OnCellAdded += OnItemAdded;
            _inventory.OnCellRemoved += OnItemRemoved;

            foreach (KeyValuePair<Item, int> pair in _inventory.GetItems())
            {
                CreateCard(pair.Key);
            }
        }

        [Button]
        public override void Hide()
        {
            _inventoryView.Hide();
            _inventoryView.OnClosedClicked -= OnCloseClicked;
            
            _inventory.OnCellAdded -= OnItemAdded;
            _inventory.OnCellRemoved -= OnItemRemoved;
            
            foreach (KeyValuePair<Item, ItemCardPresenter> pair in _cards)
            {
                ItemCardPresenter presenter = pair.Value;
                presenter.Hide();
                _cardPresenterPool.Despawn(presenter);
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
                presenter.Hide();
                _cardPresenterPool.Despawn(presenter);
            }
        }

        private void CreateCard(Item item)
        {
            ItemCardPresenter cardPresenter = _cardPresenterPool.Spawn();
            cardPresenter.transform.SetParent(_container, false);
            cardPresenter.Show(item);
            _cards.Add(item, cardPresenter);
        }

        private void OnCloseClicked() => _inventoryView.AnimateHide(() => Manager.Hide());
    }
}