using Game.Views;
using Modules.Money;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public sealed class MoneyPresenter : MonoBehaviour
    {
        [SerializeField] private MoneyView _view;
        
        private IMoneyStorage _moneyStorage;

        [Inject]
        public void Construct(IMoneyStorage moneyStorage) => _moneyStorage = moneyStorage;

        private void Start()
        {
            _moneyStorage.OnMoneyChanged += ChangeMoney;
            ChangeMoney(_moneyStorage.Money, 0);
        }
        
        private void OnDestroy() => _moneyStorage.OnMoneyChanged -= ChangeMoney;

        private void ChangeMoney(int newValue, int prevValue) => _view.AnimateMoneyChange(newValue, prevValue);
    }
}