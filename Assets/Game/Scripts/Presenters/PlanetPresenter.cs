using Game.Views;
using Modules.Planets;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetPresenter : MonoBehaviour
    {
        public string Name => _config.Name;
        
        [SerializeField] private PlanetConfig _config;
        [SerializeField] private PlanetView _view;
        [SerializeField] private IncomePresenter _incomePresenter;
        
        private IPlanet _planet;
        private PlanetPopupPresenter _popupPresenter;
        
        [Inject]
        public void Construct(PlanetPopupPresenter popupPresenter) => _popupPresenter = popupPresenter;

        private void Start()
        {
            _view.OnPlanetClicked += Unlock;
            _view.OnPlanetHold += ShowPopup;
        }

        private void OnDestroy()
        {
            _view.OnPlanetClicked -= Unlock;
            _view.OnPlanetHold -= ShowPopup;
        }

        public void Show(IPlanet planet)
        {
            _planet = planet;
            _planet.OnUnlocked += UpdateView;
            _incomePresenter.SetPlanet(_planet);
            UpdateView();
        }

        private void UpdateView()
        {
            _view.SetPlanetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _view.SetLock(!_planet.IsUnlocked);
            
            bool showPrice = !_planet.IsUnlocked;
            _view.EnablePurchasePrice(showPrice);
            
            if (showPrice)
                _view.SetPurchasePrice(_planet.Price.ToString());
        }
        
        [Button]
        private void ShowPopup()
        {
            if (_planet is { IsUnlocked: true }) 
                _popupPresenter.Show(_planet);
        }

        [Button]
        private void Unlock()
        {
            if (_planet is { CanUnlock: true }) 
                _planet.Unlock();
        }
    }
}