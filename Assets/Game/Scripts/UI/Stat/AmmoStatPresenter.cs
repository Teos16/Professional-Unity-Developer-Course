using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;

namespace Game.UI
{
    public sealed class AmmoStatPresenter : IGameUIInit, IGameUIDispose
    {
        private IGameContext _gameContext;
        private StatView _view;
        
        private Subscription<int> _subscription;
        
        public AmmoStatPresenter(IGameContext gameContext) => _gameContext = gameContext;

        public void Init(IGameUI ui)
        {
            _view = ui.GetValue(GameUIAPI.AmmoStatView);
            IGameEntity player = _gameContext.GetValue(GameContextAPI.Player);
            IWeaponEntity weapon = player.GetValue(GameEntityAPI.Weapon).Value;
            _subscription = weapon
                .GetValue(WeaponEntityAPI.Ammo)
                .Observe(UpdateStat);
        }

        public void Dispose(IGameUI entity) => _subscription.Dispose();

        private void UpdateStat(int newValue)
        {
            _view.SetText(newValue.ToString());
            _view.SetProgress(newValue == 0 ? 0 : 1);
        }
    }
}