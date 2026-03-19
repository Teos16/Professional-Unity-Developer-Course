using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class InventoryPopupView : MonoBehaviour
    {
        public event UnityAction OnClosedClicked
        {
            add => _closeButton.onClick.AddListener(value);
            remove => _closeButton.onClick.RemoveListener(value);
        }

        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _container;
        
        private ItemCardView.Pool _cardPool;

        [Inject]
        public void Construct(ItemCardView.Pool cardPool) => _cardPool = cardPool;

        public ItemCardView SpawnItem()
        {
            ItemCardView card = _cardPool.Spawn();
            card.transform.SetParent(_container, false);
            return card;
        }

        public void DespawnItem(ItemCardView card) => _cardPool.Despawn(card);
        
        public void Show() => gameObject.SetActive(true);
        
        public void Hide() => gameObject.SetActive(false);
    }
}