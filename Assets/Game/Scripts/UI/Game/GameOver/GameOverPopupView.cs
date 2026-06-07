using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class GameOverPopupView : MonoBehaviour
    {
        public event UnityAction OnContinueClicked
        {
            add => this.continueButton.onClick.AddListener(value);
            remove => this.continueButton.onClick.RemoveListener(value);
        }

        public event UnityAction OnCloseClicked
        {
            add => this.closeButton.onClick.AddListener(value);
            remove => this.closeButton.onClick.RemoveListener(value);
        }

        [SerializeField]
        private TMP_Text messageText;
        
        [SerializeField]
        private Button continueButton;
        
        [SerializeField]
        private Button closeButton;

        [Header("Animation Settings")]
        [SerializeField]
        private float bounceDuration = 0.2f;
       
        [SerializeField]
        private float popupDuration = 0.4f;
        
        [SerializeField]
        private float popupOvershoot = 1.25f;

        [SerializeField]
        private Transform _content;
        
        private Vector3 _originalButtonScale;

        private void Awake()
        {
            _originalButtonScale = continueButton.transform.localScale;
            this.AnimateRestartBounce();
        }

        public void SetMessageColor(Color color)
        {
            this.messageText.color = color;
        }

        public void SetMessage(string message)
        {
            this.messageText.text = message;
        }

        private void AnimateRestartBounce()
        {
            continueButton.transform.DOKill();
            continueButton.transform.localScale = _originalButtonScale;
            continueButton.transform
                .DOScale(_originalButtonScale * 1.2f, bounceDuration)
                .SetEase(Ease.InOutQuad)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
            
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
            this.gameObject.SetActive(false);
        }
    }
}