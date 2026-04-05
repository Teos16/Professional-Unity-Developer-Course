using Modules.Popups;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public sealed class InventoryPopupView : PopupView
    {
        public event UnityAction OnClosedClicked
        {
            add => _closeButton.onClick.AddListener(value);
            remove => _closeButton.onClick.RemoveListener(value);
        }

        [SerializeField] private Button _closeButton;

    }
}