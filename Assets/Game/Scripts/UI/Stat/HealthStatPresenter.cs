using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;

namespace Game.UI
{
    public sealed class HealthStatPresenter : IGameUIInit, IGameUIDispose
    {
        private IGameContext _gameContext;
        private StatView _view;
        
        private Subscription<int> _subscription;
        private int _maxHealth;
        
        public HealthStatPresenter(IGameContext gameContext) => _gameContext = gameContext;

        public void Init(IGameUI ui)
        {
            _view = ui.GetValue(GameUIAPI.HealthStatView);
            IGameEntity player = _gameContext.GetValue(GameContextAPI.Player);
            _maxHealth = player.GetValue(GameEntityAPI.MaxHealth).Value;
            _subscription = player
                .GetValue(GameEntityAPI.Health)
                .Observe(UpdateStat);
        }

        public void Dispose(IGameUI entity) => _subscription.Dispose();

        private void UpdateStat(int newValue)
        {
            _view.SetText(newValue.ToString());
            _view.SetProgress((float)newValue / _maxHealth);
        }
    }
}