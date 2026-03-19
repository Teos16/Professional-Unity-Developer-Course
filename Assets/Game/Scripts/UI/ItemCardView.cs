using System.Buffers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class ItemCardView : MonoBehaviour
    {
        public event UnityAction OnClicked
        {
            add => _button.onClick.AddListener(value);
            remove => _button.onClick.RemoveListener(value);
        }
        
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _count;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;
        
        public void SetTitle(string title) => _title.text = title;
        
        public void SetCount(string count) => _count.text = count;
        
        public void SetIcon(Sprite icon) => _icon.sprite = icon;

        public class Pool : MonoMemoryPool<ItemCardView> { }
    }
}