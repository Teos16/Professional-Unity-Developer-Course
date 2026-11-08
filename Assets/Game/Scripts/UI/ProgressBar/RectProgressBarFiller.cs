using UnityEngine;

namespace Game
{
    public sealed class RectProgressBarFiller : ProgressBarFiller
    {
        [SerializeField] private RectTransform _rectTransform;

        public override float FillAmount
        {
            get => _rectTransform.anchorMax.x;
            set
            {
                Vector2 anchorMax = _rectTransform.anchorMax;
                anchorMax.x = value;
                _rectTransform.anchorMax = anchorMax;
            }
        }
    }
}
