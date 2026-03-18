using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class ItemPopupView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TMP_Text _count;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _consumeButton;
        
        private ItemPopupPresenter _presenter;

        [Inject]
        public void Construct(ItemPopupPresenter presenter)
        {
            _presenter = presenter;
        }

        private void OnEnable()
        {
            _consumeButton.onClick.AddListener(_presenter.OnConsume);
            _closeButton.onClick.AddListener(_presenter.OnClose);
        }
        
        private void OnDisable()
        {
            _consumeButton.onClick.RemoveListener(_presenter.OnConsume);
            _closeButton.onClick.RemoveListener(_presenter.OnClose);
        }

        public void SetTitle(string title) => _title.text = title;
        
        public void SetDescription(string description) => _description.text = description;
        
        public void SetCount(string count) => _count.text = count.ToString();
        
        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        
        public void SetConsumable(bool consumable) => _consumeButton.gameObject.SetActive(consumable);
        
        public void SetConsumeAllowed(bool allowed) => _consumeButton.interactable = allowed;

        public void Show() => gameObject.SetActive(true);
        
        public void Hide() => gameObject.SetActive(false);
    }
}