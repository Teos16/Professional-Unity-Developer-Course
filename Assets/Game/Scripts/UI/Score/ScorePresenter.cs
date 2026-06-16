using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;

namespace Game.UI
{
    public sealed class ScorePresenter : IGameUIInit, IGameUIDispose
    {
        private readonly IGameContext _gameContext;
        
        private ScoreView _view;

        private Subscription<int> _subscription;

        public ScorePresenter(IGameContext gameContext) => _gameContext = gameContext;

        public void Init(IGameUI ui)
        {
            _view = ui.GetValue(GameUIAPI.ScoreView);
            _subscription = _gameContext.GetValue(GameContextAPI.Score).Observe(OnScoreChanged);
        }

        public void Dispose(IGameUI ui) => _subscription.Dispose();

        private void OnScoreChanged(int score)
        {
            _view.SetScore($"{score}");
        }
    }
}