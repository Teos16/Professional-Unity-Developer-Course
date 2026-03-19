using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public sealed class ItemPopupView : MonoBehaviour, IItemPopupView
    {
        public event UnityAction OnConsumeClicked
        {
            add => _consumeButton.onClick.AddListener(value);
            remove => _consumeButton.onClick.RemoveListener(value);
        }

        public event UnityAction OnCloseClicked
        {
            add => _closeButton.onClick.AddListener(value);
            remove => _closeButton.onClick.RemoveListener(value);
        }

        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TMP_Text _count;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _consumeButton;

        public void SetTitle(string title) => _title.text = title;
        
        public void SetDescription(string description) => _description.text = description;
        
        public void SetCount(string count) => _count.text = count;
        
        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        
        public void SetConsumable(bool consumable) => _consumeButton.gameObject.SetActive(consumable);
        
        public void SetConsumeAllowed(bool allowed) => _consumeButton.interactable = allowed;

        public void Show() => gameObject.SetActive(true);
        
        public void Hide() => gameObject.SetActive(false);
    }
}