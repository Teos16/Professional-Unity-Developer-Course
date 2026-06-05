using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class GameOverPopupView : MonoBehaviour
    {
        public event UnityAction OnRestartClicked
        {
            add => restartButton.onClick.AddListener(value);
            remove => restartButton.onClick.RemoveListener(value);
        }

        public event UnityAction OnCloseClicked
        {
            add => closeButton.onClick.AddListener(value);
            remove => closeButton.onClick.RemoveListener(value);
        }

        [SerializeField] private TMP_Text messageText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button closeButton;

        [Header("Animation Settings")]
        [SerializeField] private float bounceDuration = 0.2f;
        [SerializeField] private float popupDuration = 0.4f;
        [SerializeField] private float popupOvershoot = 1.25f;
        [SerializeField] private Transform _content;
        
        private Vector3 _originalButtonScale;

        private void Awake()
        {
            _originalButtonScale = restartButton.transform.localScale;
            AnimateRestartBounce();
        }

        public void SetMessageColor(Color color)
        {
            messageText.color = color;
        }

        public void SetMessage(string message)
        {
            messageText.text = message;
        }

        private void AnimateRestartBounce()
        {
            restartButton.transform.DOKill();
            restartButton.transform.localScale = _originalButtonScale;
            restartButton.transform
                .DOScale(_originalButtonScale * 1.2f, bounceDuration)
                .SetEase(Ease.InOutQuad)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            
            _content.DOKill();
            _content.localScale = Vector3.zero;

            _content
                .DOScale(Vector3.one * popupOvershoot, popupDuration * 0.6f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    _content
                        .DOScale(Vector3.one, popupDuration * 0.4f)
                        .SetEase(Ease.OutBounce);
                });
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}