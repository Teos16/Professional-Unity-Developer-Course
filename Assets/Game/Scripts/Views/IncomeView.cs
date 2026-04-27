using System;
using Modules.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class IncomeView : MonoBehaviour
    {
        public event Action OnPlanetClicked
        {
            add => _planetButton.OnClick += value;  
            remove => _planetButton.OnClick -= value;  
        }
        
        [SerializeField] private SmartButton _planetButton;
        [SerializeField] private Image _progressBarBackground;
        [SerializeField] private Image _progressBarFilling;
        [SerializeField] private TMP_Text _incomeProgressTime;
        [SerializeField] private GameObject _coin;

        [SerializeField, Header("Coin particle")] private ParticleAnimator _coinParticleAnimator;
        [SerializeField] private Transform _coinParticleTarget;
        
        private float _coinAnimationDuration;

        private void Start() => _progressBarFilling.fillAmount = 0;
        
        public void EnableCoin(bool isEnabled) => _coin.SetActive(isEnabled);
        
        public void SetCoinAnimationDuration(float duration) => _coinAnimationDuration = duration;

        public void SetProgressBarEnabled(bool isEnabled)
        {
            _progressBarBackground.enabled = isEnabled;
            _progressBarFilling.gameObject.SetActive(isEnabled);
        }

        public void SetProgressTimeEnabled(bool isEnabled) => _incomeProgressTime.gameObject.SetActive(isEnabled);

        public void SetProgressTime(string formattedTime) => _incomeProgressTime.text = formattedTime;
        
        public void SetProgressOnBar(float progress) => _progressBarFilling.fillAmount = progress;
        
        public void LaunchCoin(Action callback)
        {
            _coinParticleAnimator.Emit(_coin.transform.position, 
                                        _coinParticleTarget.position, 
                                        _coinAnimationDuration,
                                        callback);
        }
    }
}