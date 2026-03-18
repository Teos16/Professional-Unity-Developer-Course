using Modules.Inventories;
using SampleGame.Gameplay;
using Sirenix.OdinInspector;

namespace Game.Scripts.UI
{
    public sealed class ItemPopupPresenter
    {
        private readonly ItemPopupView _view;

        private readonly Inventory<Item> _inventory;
        private readonly ItemConsumer _itemConsumer;
        
        [ShowInInspector, ReadOnly] private Item _targetItem;

        public ItemPopupPresenter(ItemPopupView view, Inventory<Item> inventory, ItemConsumer itemConsumer)
        {
            _view = view;
            _inventory = inventory;
            _itemConsumer = itemConsumer;
        }
        
        [Button]
        public void Show(Item item)
        {
            _targetItem = item;
            
            UpdateView();
            _view.Show();
            
            _inventory.OnCountChanged += OnItemCountChanged;
        }
        
        [Button]
        public void Hide()
        {
            _inventory.OnCountChanged -= OnItemCountChanged;
            _view.Hide();
        }
        
        // View Event
        public void OnConsume()
        {
            if(_targetItem != null && _itemConsumer.CanConsume(_targetItem))
                _itemConsumer.Consume(_targetItem);
        }

        // View Event
        public void OnClose() => Hide();

        private void UpdateView()
        {
            _view.SetTitle(_targetItem.Title);
            _view.SetDescription(_targetItem.Description);
            _view.SetIcon(_targetItem.Icon);
            _view.SetConsumable(_targetItem.IsConsumable);
            UpdateCount();
            UpdateConsumeAllowed();
        }

        // Model Event
        private void OnItemCountChanged(Item item, int count)
        {
            if (item == _targetItem)
            {
                UpdateCount();
                UpdateConsumeAllowed();
            }
        }

        private void UpdateConsumeAllowed() => _view.SetConsumeAllowed(_itemConsumer.CanConsume(_targetItem));

        private void UpdateCount() => _view.SetCount(_inventory.GetCount(_targetItem).ToString());
    }
}