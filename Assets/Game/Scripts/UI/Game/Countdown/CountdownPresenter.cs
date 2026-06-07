using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using TMPro;

namespace Game.UI
{
    public sealed class CountdownPresenter : IGameUIInit, IGameUIDispose
    {
        private readonly IGameContext _gameContext;
        private TMP_Text _view;
        
        private Subscription<float> _subscription;

        public CountdownPresenter(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void Init(IGameUI ui)
        {
            _view = ui.GetValue(GameUIAPI.CountdownView);
            _subscription = _gameContext
                .GetGameTime()
                .Observe(this.OnGameTimeChanged);
        }
        
        public void Dispose(IGameUI entity)
        {
            _subscription.Dispose();
        }

        private void OnGameTimeChanged(float time)
        {
            _view.text = $"Game Time: {time:F0}";
        }
    }
}