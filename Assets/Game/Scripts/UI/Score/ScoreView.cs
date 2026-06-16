using TMPro;
using UnityEngine;
using DG.Tweening;

namespace Game.UI
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _bounceScale = 1.3f;
        [SerializeField] private float _duration = 0.3f;

        private Vector3 _originalScale;

        private void Awake()
        {
            _originalScale = _text.transform.localScale;
        }

        public void SetScore(string text)
        {
            _text.text = text;
            PlayBounce();
        }

        private void PlayBounce()
        {
            _text.transform.DOKill();

            _text.transform.localScale = _originalScale;

            _text.transform
                .DOScale(_originalScale * _bounceScale, _duration / 2f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    _text.transform
                        .DOScale(_originalScale, _duration / 2f)
                        .SetEase(Ease.InBounce);
                });
        }
    }
}