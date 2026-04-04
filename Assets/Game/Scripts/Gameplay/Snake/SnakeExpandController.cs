using System;
using Modules;
using Zenject;

namespace Game
{
    public sealed class SnakeExpandController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinManager _coinManager;

        public SnakeExpandController(ISnake snake, CoinManager coinManager)
        {
            _snake = snake;
            _coinManager = coinManager;
        }

        public void Initialize() => _coinManager.OnCoinPickedUp += ExpandSnake;

        public void Dispose() => _coinManager.OnCoinPickedUp -= ExpandSnake;

        private void ExpandSnake(ICoin coin) => _snake.Expand(coin.Bones);
    }
}