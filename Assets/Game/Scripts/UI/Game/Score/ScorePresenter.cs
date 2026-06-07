using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;

namespace Game.UI
{
    public sealed class ScorePresenter : IGameUIInit, IGameUIDispose
    {
        private readonly ScoreView _view;
        private readonly TeamType _teamType;
        private readonly IGameContext _gameContext;

        private Subscription<int> _subscription;

        public ScorePresenter(ScoreView view, TeamType teamType, IGameContext gameContext)
        {
            _view = view;
            _teamType = teamType;
            _gameContext = gameContext;
        }

        public void Init(IGameUI entity)
        {
            _subscription = _gameContext.GetPlayers()[_teamType]
                .GetValue(PlayerContextAPI.Score)
                .Observe(this.OnScoreChanged);
        }

        public void Dispose(IGameUI entity)
        {
            _subscription.Dispose();
        }

        private void OnScoreChanged(int score)
        {
            _view.SetScore($"Score: {score}");
        }
    }
}