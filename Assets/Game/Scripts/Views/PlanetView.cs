using System;
using Modules.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class PlanetView : MonoBehaviour
    {
        public event Action OnPlanetClicked  
        {  
            add => _planetButton.OnHold += value;  
            remove => _planetButton.OnHold -= value;  
        } 
        
        [SerializeField] private Image _planetIcon;
        [SerializeField] private SmartButton _planetButton;
        [SerializeField] private GameObject _lock;
        [SerializeField] private TMP_Text _purhasePrice;
        [SerializeField] private GameObject _purhasePriceObject;

        public void SetPlanetIcon(Sprite planetIcon) => _planetIcon.sprite = planetIcon;
        
        public void SetLock(bool isLocked) => _lock.SetActive(isLocked);
        
        public void SetPurchasePrice(string price) => _purhasePrice.text = price;
        
        public void EnablePurchasePrice(bool isEnabled) => _purhasePriceObject.SetActive(isEnabled);
    }
}