using Modules.Popups;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class InventoryButtonPresenter : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private PopupManager _manager;
        
        [Inject]
        public void Construct(PopupManager manager) => _manager = manager;

        private void OnEnable() => _button.onClick.AddListener(OnClicked);

        private void OnDisable() => _button.onClick.RemoveListener(OnClicked);

        private void OnClicked() => _manager.Show<InventoryPopupPresenter>(new InventoryPopupPresenter.Args
        {
            animateShow = true
        });
    }
}