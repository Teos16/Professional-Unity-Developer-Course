using Game.Views;
using Modules.Planets;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Presenters
{
    public sealed class IncomePresenter : MonoBehaviour
    {
        [SerializeField] private IncomeView _view;
        [SerializeField] private float _coinAnimationDuration = 1f;
        
        private IPlanet _planet;
        
        private void Start()
        {
            DisableElements();
            
            _view.SetCoinAnimationDuration(_coinAnimationDuration);
            
            _view.OnPlanetClicked += StartIncomeGathering;
            _view.OnCoinParticleAnimationComplete += GatherIncome;
        }

        private void OnDestroy()
        {
            _view.OnPlanetClicked -= StartIncomeGathering;
            _view.OnCoinParticleAnimationComplete -= GatherIncome;
        }


        public void SetPlanet(IPlanet planet)
        {
            _planet = planet;
            
            _planet.OnUnlocked += Show;
            _planet.OnIncomeReady += ShowCoin;
            _planet.OnIncomeTimeChanged += UpdateProgress;
            
            Show();
        }

        [Button]
        private void StartIncomeGathering()
        {
            if (CanCollectIncome()) 
                _view.LaunchCoin();
        }

        private void GatherIncome() => _planet.GatherIncome();

        [Button]
        private void Show()
        {
            if (_planet == null) return;
            
            _view.EnableCoin(_planet.IsUnlocked && _planet.IsIncomeReady);
            _view.SetProgressBarEnabled(_planet.IsUnlocked && !_planet.IsIncomeReady);
            _view.SetProgressTimeEnabled(_planet.IsUnlocked && !_planet.IsIncomeReady);
        }

        [Button]
        private void Hide()
        {
            _planet.OnUnlocked -= Show;
            _planet.OnIncomeReady -= ShowCoin;
            _planet.OnIncomeTimeChanged -= UpdateProgress;
            
            DisableElements();
        }

        private void DisableElements()
        {
            _view.EnableCoin(false);
            _view.SetProgressBarEnabled(false);
            _view.SetProgressTimeEnabled(false);
        }

        private void ShowCoin(bool isIncomeReady)
        {
            _view.EnableCoin(isIncomeReady);
            _view.SetProgressBarEnabled(!isIncomeReady);
            _view.SetProgressTimeEnabled(!isIncomeReady);
        }

        private void UpdateProgress(float timeLeft)
        {
            if(timeLeft > 0)
            {
                int minutes = Mathf.FloorToInt(timeLeft / 60f);
                int seconds = Mathf.FloorToInt(timeLeft % 60f);
                _view.SetProgressTime(minutes, seconds);
                _view.SetProgressOnBar(_planet.IncomeProgress);
            }
        }

        private bool CanCollectIncome() => _planet != null && _planet.IsUnlocked && _planet.IsIncomeReady;
    }
}