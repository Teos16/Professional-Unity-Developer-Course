using System;
using Modules.Inventories;
using SampleGame.Gameplay;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class ItemCardPresenter : IDisposable
    {
        public ItemCardView View => _view;
        
        private readonly ItemCardView _view;
        private readonly Item _item;
        private readonly Inventory<Item> _inventory;
        private readonly ItemPopupPresenter _itemPopup;

        public ItemCardPresenter(
            ItemCardView view, 
            Item item, 
            Inventory<Item> inventory, 
            ItemPopupPresenter popupPresenter)
        {
            _view = view;
            _item = item;
            _inventory = inventory;
            _itemPopup = popupPresenter;

            _view.SetTitle(_item.Title);
            _view.SetCount(_inventory.GetCount(_item).ToString());
            _view.SetIcon(_item.Icon);
            _view.OnClicked += OnClicked;
            
            _inventory.OnCountChanged += OnCountChanged;
        }

        public void Dispose()
        {
            _inventory.OnCountChanged -= OnCountChanged;
            _view.OnClicked += OnClicked;
        }

        // Model Event
        private void OnCountChanged(Item item, int count)  
        {        
            if (item == _item)   
                _view.SetCount(count.ToString());  
        }
    
        // UI Event
        private void OnClicked() => _itemPopup.Show(_item);
        
        public class Factory : PlaceholderFactory<Item, ItemCardView, ItemCardPresenter> { }
    }
}