using Game.Views;
using Modules.Planets;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetPresenter : MonoBehaviour
    {
        [SerializeField] private PlanetView _view;
        [SerializeField] private IncomePresenter _incomePresenter;
        
        private IPlanet _planet;
        private PlanetPopupPresenter _popupPresenter;
        
        [Inject]
        public void Construct(PlanetPopupPresenter popupPresenter) => _popupPresenter = popupPresenter;

        private void Start() => _view.OnPlanetClicked += Interact;

        private void OnDestroy() => _view.OnPlanetClicked -= Interact;

        public void Show(IPlanet planet)
        {
            _planet = planet;
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

        private void Interact()
        {
            if (_planet != null && _planet.CanUnlock)
                Unlock();
            else if (_planet != null && _planet.IsUnlocked)
                ShowPopup();
        }
        
        private void ShowPopup()
        {
            _popupPresenter.gameObject.SetActive(true);
            _popupPresenter.Show(_planet);
        }

        [Button]
        private void Unlock()
        {
            _planet.Unlock();
            UpdateView();
        }
    }
}