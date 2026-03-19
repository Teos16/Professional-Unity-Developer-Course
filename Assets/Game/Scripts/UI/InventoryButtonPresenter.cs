using System;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public sealed class InventoryButtonPresenter : IDisposable
    {
        private readonly Button _button;
        private readonly InventoryPopupPresenter _inventoryPresenter;
        
        public InventoryButtonPresenter(Button button, InventoryPopupPresenter inventoryPresenter)
        {
            _button = button;
            _inventoryPresenter = inventoryPresenter;
            
            button.onClick.AddListener(OnClicked);
        }

        public void Dispose() => _button.onClick.RemoveListener(OnClicked);

        private void OnClicked() => _inventoryPresenter.Show();
    }
}