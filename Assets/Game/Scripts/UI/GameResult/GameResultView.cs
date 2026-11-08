using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class GameResultView : MonoBehaviour
    {
        public event Action OnMenuClicked;

        [SerializeField] private TMP_Text _caption;
        [SerializeField] private Button _menuButton;

        private void Awake() => _menuButton.onClick.AddListener(InvokeMenuClicked);

        private void OnDestroy() => _menuButton.onClick.RemoveListener(InvokeMenuClicked);

        public void Show(string caption)
        {
            _caption.text = caption;
            gameObject.SetActive(true);
        }

        public void Hide() => gameObject.SetActive(false);

        private void InvokeMenuClicked() => OnMenuClicked?.Invoke();
    }
}
