using System.Text;
using Game.Views;
using Modules.Planets;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Presenters
{
    public sealed class IncomePresenter : MonoBehaviour
    {
        private const string MINUTES_TEXT = "m : ";
        private const string SECONDS_TEXT = "s";
        
        [SerializeField] private IncomeView _view;
        [SerializeField] private float _coinAnimationDuration = 1f;
        
        private IPlanet _planet;
        
        private readonly StringBuilder _builder = new();

        private bool _isCollected;
        
        private void Start()
        {
            DisableElements();
            
            _view.SetCoinAnimationDuration(_coinAnimationDuration);
            
            _view.OnPlanetClicked += StartIncomeGathering;
        }

        private void OnDestroy() => _view.OnPlanetClicked -= StartIncomeGathering;


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
            {
                _view.LaunchCoin(OnCoinLaunch);
                _view.EnableCoin(false);
                _isCollected = true;
            }
        }

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
                var formattedTime = FormattedTime(minutes, seconds);
                _view.SetProgressTime(
                    formattedTime);
                _view.SetProgressOnBar(_planet.IncomeProgress);
            }
        }

        private string FormattedTime(int minutes, int seconds)
        {
            _builder.Clear();
            _builder.Append(minutes)
                .Append(MINUTES_TEXT)
                .Append(seconds)
                .Append(SECONDS_TEXT);
            return _builder.ToString();
        }

        private void OnCoinLaunch()
        {
            _planet.GatherIncome();
            _isCollected = false;
        }

        private bool CanCollectIncome() => _planet is { IsUnlocked: true, IsIncomeReady: true } && !_isCollected;
    }
}