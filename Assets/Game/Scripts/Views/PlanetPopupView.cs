using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class PlanetPopupView : MonoBehaviour
    {
        public event UnityAction OnCloseClicked  
        {  
            add => _closeButton.onClick.AddListener(value);  
            remove => _closeButton.onClick.RemoveListener(value);  
        } 
        
        public event UnityAction OnUpgradeClicked  
        {  
            add => _upgradeButton.onClick.AddListener(value);  
            remove => _upgradeButton.onClick.RemoveListener(value);  
        }

        [SerializeField, Header("Upgrade button")] private Button _upgradeButton;
        [SerializeField] private GameObject _upgradeElement;
        [SerializeField] private GameObject _maxLevelTextOnButton;
        [SerializeField] private TMP_Text _upgradeCost;
        
        [SerializeField, Header("Data window and close button")] private GameObject _popup;
        [SerializeField] private Image _avatar;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _planetName;
        [SerializeField] private TMP_Text _planetPopulation;
        [SerializeField] private TMP_Text _planetLevel;
        [SerializeField] private TMP_Text _planetIncome;

        public void Show() => _popup.SetActive(true);
        
        public void Hide() => _popup.SetActive(false);
        
        #region Upgrade Button
        
        public void SetUpgradeButtonContent(bool isMaxLevel)
        {
            _maxLevelTextOnButton.SetActive(isMaxLevel);
            _upgradeElement.SetActive(!isMaxLevel);
        }
        
        public void SetUpgradeButtonEnabled(bool isEnabled) => _upgradeButton.interactable = isEnabled;
        
        public void SetUpgradeCost(string cost) => _upgradeCost.text = cost;
        
        #endregion
        
        #region Data Window

        public void SetPlanetName(string planetName) => _planetName.text = planetName;
        
        public void SetPlanetPopulation(string population) => _planetPopulation.text = $"Population: {population}";

        public void SetPlanetLevel(string level, string maxLevel) => _planetLevel.text = $"Level: {level} / {maxLevel}";

        public void SetPlanetIncome(string income) => _planetIncome.text = $"Income: {income} / sec";
        
        public void SetAvatar(Sprite sprite) => _avatar.sprite = sprite;

        #endregion
    }
}