using System.Text;
using Game.Views;
using Modules.Planets;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Presenters
{
    public sealed class PlanetPopupPresenter : MonoBehaviour
    {
        private const string LEVEL_TEXT = "Level: ";
        private const string POPULATION_TEXT = "Population: ";
        private const string INCOME_TEXT = "Income: ";
        private const string SLASH_TEXT = " / ";
        private const string SEC_TEXT = " / sec";
        
        [SerializeField] private PlanetPopupView _view;
        
        private readonly StringBuilder _builder = new();
        
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
            OnPopulationChanged(_planet.Population);
            
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
            
            _view.SetPlanetLevel(LevelText(level));
            _view.SetPlanetIncome(IncomeText());
            _view.SetUpgradeCost(_planet.Price.ToString());
        }

        private void OnPopulationChanged(int populationCount) =>
            _view.SetPlanetPopulation(PopulationText(populationCount));

        private void UpgradePlanet() => _planet.Upgrade();

        private string IncomeText()
        {
            _builder.Clear();
            _builder.Append(INCOME_TEXT)
                .Append(_planet.MinuteIncome)
                .Append(SEC_TEXT);
            return _builder.ToString();
        }

        private string LevelText(int level)
        {
            _builder.Clear();
            _builder.Append(LEVEL_TEXT)
                .Append(level)
                .Append(SLASH_TEXT)
                .Append(_planet.MaxLevel);
            return _builder.ToString();
        }

        private string PopulationText(int populationCount)
        {
            _builder.Clear();
            _builder
                .Append(POPULATION_TEXT)
                .Append(populationCount);
            return _builder.ToString();
        }
    }
}