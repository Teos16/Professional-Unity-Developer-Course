using Game.Views;
using Modules.Planets;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Presenters
{
    public sealed class PlanetPopupPresenter : MonoBehaviour
    {
        [SerializeField] private PlanetPopupView _view;
        
        private IPlanet _planet;
        
        private void Awake()
        {
            _view.OnCloseClicked += Hide;
            _view.OnUpgradeClicked += UpgradePlanet;
        }

        private void OnDestroy()
        {
            _view.OnCloseClicked -= Hide;
            _view.OnUpgradeClicked -= UpgradePlanet;
        }
        
        [Button]
        public void Show(IPlanet planet)
        {
            _planet = planet;
            
            _planet.OnUpgraded += UpdateData;
            _planet.OnPopulationChanged += OnPopulationChanged;
            
            UpdateData(_planet.Level);

            _view.Show();
            
            _view.SetAvatar(_planet.GetIcon(_planet.IsUnlocked));
            _view.SetPlanetName(_planet.Name);
        }

        private void Hide()
        {
            _planet.OnUpgraded -= UpdateData;
            _planet.OnPopulationChanged -= OnPopulationChanged;

            _planet = null;
            _view.Hide();
        }

        private void UpdateData(int level)
        {
            _view.SetUpgradeButtonEnabled(_planet.CanUpgrade);
            _view.SetUpgradeButtonContent(_planet.IsMaxLevel);
            _view.SetPlanetLevel(level.ToString(), _planet.MaxLevel.ToString());
            _view.SetUpgradeCost(_planet.Price.ToString());
            _view.SetPlanetIncome(_planet.MinuteIncome.ToString());
        }

        private void OnPopulationChanged(int populationCount) => 
            _view.SetPlanetPopulation(populationCount.ToString());

        private void UpgradePlanet() => _planet.Upgrade();
    }
}