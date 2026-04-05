using System;
using Modules.Inventories;
using Modules.Popups;
using SampleGame.Gameplay;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class ItemCardPresenter : MonoBehaviour
    {
        public ItemCardView View => _view;
        
        [SerializeField] private ItemCardView _view;
        private Item _item;
        private Inventory<Item> _inventory;
        private PopupManager _popupManager;

        [Inject]
        public void Construct(Inventory<Item> inventory, PopupManager popupManager)
        {
            _inventory = inventory;
            _popupManager = popupManager;
        }

        public void Show(Item item)
        {
            if( _item != item)
            {
                _item = item;
                _view.SetTitle(_item.Title);
                _view.SetCount(_inventory.GetCount(_item).ToString());
                _view.SetIcon(_item.Icon);
            }
            
            _view.OnClicked += OnClicked;
            _inventory.OnCountChanged += OnCountChanged;
        }

        public void Hide()
        {
            _view.OnClicked -= OnClicked;
            _inventory.OnCountChanged -= OnCountChanged;
        }

        // Model Event
        private void OnCountChanged(Item item, int count)  
        {        
            if (item == _item)   
                _view.SetCount(count.ToString());  
        }
    
        // UI Event
        private void OnClicked() => _popupManager.Show<ItemPopupPresenter>(new ItemPopupPresenter.Args(_item));

        public class Pool : MonoMemoryPool<ItemCardPresenter> { }
    }
}