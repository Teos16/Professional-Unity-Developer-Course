using System;
using Modules;
using Zenject;

namespace Game
{
    public sealed class SnakeSpeedController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IDifficulty _difficulty;

        public SnakeSpeedController(ISnake snake, IDifficulty difficulty)
        {
            _snake = snake;
            _difficulty = difficulty;
        }

        public void Initialize() => _difficulty.OnStateChanged += SetSpeed;

        public void Dispose() => _difficulty.OnStateChanged -= SetSpeed;

        private void SetSpeed() => _snake.SetSpeed(_difficulty.Current);
    }
}