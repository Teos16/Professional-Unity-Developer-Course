using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.Views
{
    public sealed class MoneyView : MonoBehaviour
    {
        private const float ANIMATION_DURATION = 1f;
        
        [SerializeField] private TMP_Text _money;
        
        public void AnimateMoneyChange(int newValue, int prevValue)
        {
            DOTween.To(
                () => prevValue,
                x => _money.text = x.ToString(),
                newValue,
                ANIMATION_DURATION
            ).SetEase(Ease.OutExpo);
        }
    }
}