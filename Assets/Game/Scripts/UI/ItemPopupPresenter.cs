using Modules.Inventories;
using Modules.Popups;
using SampleGame.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class ItemPopupPresenter : PopupPresenter<ItemPopupPresenter.Args>
    {
        public readonly struct Args : IPopupArgs
        {
            public readonly Item item;
            
            public Args(Item item) => this.item = item;
        }
        
        [SerializeField]
        private ItemPopupView _view;

        private Inventory<Item> _inventory;
        private ItemConsumer _itemConsumer;
        
        [ShowInInspector, ReadOnly] private Item _targetItem;
        
        [Inject]
        public void Construct(Inventory<Item> inventory, ItemConsumer itemConsumer)
        {
            _inventory = inventory;
            _itemConsumer = itemConsumer;
        }

        [Button]
        public void ChangeItem(Item item)
        {
            if(_targetItem == item)
                return;
            
            _targetItem = item;
            UpdateView();
        }
        
        public override void Show(Args args)
        {
            _targetItem = args.item;
            
            UpdateView();
            _view.Show();
            
            _view.OnCloseClicked += OnClose;
            _view.OnConsumeClicked += OnConsume;
            _inventory.OnCountChanged += OnItemCountChanged;
        }
        
        public override void Hide()
        {
            _view.OnCloseClicked -= OnClose;
            _view.OnConsumeClicked -= OnConsume;
            _inventory.OnCountChanged -= OnItemCountChanged;
            _view.Hide();
        }
        
        // View Event
        private void OnConsume()
        {
            if(_targetItem != null && _itemConsumer.CanConsume(_targetItem))
                _itemConsumer.Consume(_targetItem);
        }

        // View Event
        private void OnClose()
        {
            Manager.Show<InventoryPopupPresenter>(new InventoryPopupPresenter.Args
            {
                animateShow = false
            });
        }

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