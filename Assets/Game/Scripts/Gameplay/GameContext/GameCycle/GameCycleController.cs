using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class GameCycleController : IGameContextInit, IGameContextEnable, IGameContextTick
    {
        private IVariable<float> _gameTime;
        private IEvent _gameFinishedEvent;
        private IEvent _gameStartedEvent;

        public void Init(IGameContext context)
        {
            _gameTime = context.GetGameTime();
            _gameStartedEvent = context.GetGameStartedEvent();
            _gameFinishedEvent = context.GetGameFinishedEvent();
        }

        public void Enable(IGameContext context)
        {
            _gameStartedEvent.Invoke();
            Debug.Log("<color=yellow>Game Started!</color>");
        }

        public void Tick(IGameContext context, float deltaTime)
        {
            if (_gameTime.Value <= 0)
                return;

            _gameTime.Value -= deltaTime;

            if (_gameTime.Value <= 0)
            {
                _gameFinishedEvent.Invoke();
                context.Disable();
                Debug.Log("<color=yellow>Game Finished</color>");
            }
        }
    }
}