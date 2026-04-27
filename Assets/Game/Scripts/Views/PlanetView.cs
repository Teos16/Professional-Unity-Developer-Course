using System;
using Modules.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class PlanetView : MonoBehaviour
    {
        public event Action OnPlanetClicked  
        {  
            add => _planetButton.OnClick += value;  
            remove => _planetButton.OnClick -= value;  
        } 
        
        public event Action OnPlanetHold  
        {  
            add => _planetButton.OnHold += value;  
            remove => _planetButton.OnHold -= value;  
        } 
        
        [SerializeField] private Image _planetIcon;
        [SerializeField] private SmartButton _planetButton;
        [SerializeField] private GameObject _lock;
        [SerializeField] private TMP_Text _purchasePrice;
        [SerializeField] private GameObject _purchasePriceObject;

        public void SetPlanetIcon(Sprite planetIcon) => _planetIcon.sprite = planetIcon;
        
        public void SetLock(bool isLocked) => _lock.SetActive(isLocked);
        
        public void SetPurchasePrice(string price) => _purchasePrice.text = price;
        
        public void EnablePurchasePrice(bool isEnabled) => _purchasePriceObject.SetActive(isEnabled);
    }
}