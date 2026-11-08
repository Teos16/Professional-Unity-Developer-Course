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

        private void Awake() => _menuButton.onClick.AddListener(this.InvokeMenuClicked);

        private void OnDestroy() => _menuButton.onClick.RemoveListener(this.InvokeMenuClicked);

        public void Show(string caption)
        {
            _caption.text = caption;
            this.gameObject.SetActive(true);
        }

        public void Hide() => this.gameObject.SetActive(false);

        private void InvokeMenuClicked() => this.OnMenuClicked?.Invoke();
    }
}