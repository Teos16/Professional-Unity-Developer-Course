using Atomic.Elements;
using Game.Gameplay;

namespace Game.App
{
    public sealed class LevelIncrementController : IGameContextInit, IGameContextDispose
    {
        private readonly IAppContext _appContext;
        private ISignal _gameOverEvent;

        public LevelIncrementController(IAppContext appContext)
        {
            _appContext = appContext;
        }

        public void Init(IGameContext context)
        {
            _gameOverEvent = context.GetGameFinishedEvent();
            _gameOverEvent.OnEvent += OnGameCompleted;
        }

        public void Dispose(IGameContext entity)
        {
            _gameOverEvent.OnEvent -= OnGameCompleted;
        }

        private void OnGameCompleted()
        {
            _appContext.TryIncrementLevel();
        }
    }
}