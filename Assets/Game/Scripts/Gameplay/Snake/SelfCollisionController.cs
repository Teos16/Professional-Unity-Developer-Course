using System;
using Modules;
using Zenject;

namespace Game
{
    public sealed class SelfCollisionController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly GameCycle _gameCycle;

        public SelfCollisionController(ISnake snake, GameCycle gameCycle)
        {
            _snake = snake;
            _gameCycle = gameCycle;
        }

        public void Initialize() => _snake.OnSelfCollided += OnSelfCollided;

        public void Dispose() => _snake.OnSelfCollided -= OnSelfCollided;

        private void OnSelfCollided() => _gameCycle.Lose();
    }
}