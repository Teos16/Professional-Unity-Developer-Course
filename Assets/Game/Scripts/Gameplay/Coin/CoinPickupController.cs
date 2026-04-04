using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class CoinPickupController : IInitializable, IDisposable
    {
        private readonly CoinManager _coinManager;
        private readonly ISnake _snake;

        public CoinPickupController(CoinManager coinManager, ISnake snake)
        {
            _coinManager = coinManager;
            _snake = snake;
        }

        public void Initialize() => _snake.OnMoved += OnSnakeMoved;

        public void Dispose() => _snake.OnMoved -= OnSnakeMoved;

        private void OnSnakeMoved(Vector2Int headPosition) => _coinManager.TryPickUpCoinAt(headPosition);
    }
}