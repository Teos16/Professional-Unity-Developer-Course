using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;

namespace Game.UI
{
    public sealed class HealthScreenPresenter : IGameUIInit, IGameUIDispose
    {
        private readonly IGameContext _gameContext;
        private HealthScreenView _view;
        
        private Subscription<int> _subscription;
        private int _maxHealth;
        
        public HealthScreenPresenter(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        public void Init(IGameUI ui)
        {
            _view = ui.GetValue(GameUIAPI.HealthScreenView);
            IGameEntity player = _gameContext.GetValue(GameContextAPI.Player);
            _maxHealth = player.GetValue(GameEntityAPI.MaxHealth).Value;
            _subscription = player
                .GetValue(GameEntityAPI.Health)
                .Subscribe(OnHealthChanged);
            _subscription = player
                .GetValue(GameEntityAPI.TakeDamageCommand)
                .Subscribe(OnDamageTaken);
        }

        public void Dispose(IGameUI ui) => _subscription.Dispose();

        private void OnHealthChanged(int newHealth) => _view.ChangePercent((float) newHealth / _maxHealth);

        private void OnDamageTaken(int damage) => _view.TakeDamage(damage);
    }
}