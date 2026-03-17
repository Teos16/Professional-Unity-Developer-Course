using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class RewardApplier : IInitializable, IDisposable
    {
        private readonly CoinManager _coinManager;
        private readonly ISnake _snake;
        private readonly IScore _score;

        public RewardApplier(CoinManager coinManager, ISnake snake, IScore score)
        {
            _coinManager = coinManager;
            _snake = snake;
            _score = score;
        }

        public void Initialize()
        {
            _snake.OnMoved += OnSnakeMoved;
            _coinManager.OnCoinPickedUp += OnCoinPickedUp;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
            _coinManager.OnCoinPickedUp -= OnCoinPickedUp;
        }

        private void OnSnakeMoved(Vector2Int headPosition)
        {
            _coinManager.TryPickUpCoinAt(headPosition);
        }

        private void OnCoinPickedUp(ICoin coin)
        {
            _snake.Expand(coin.Bones);
            _score.Add(coin.Score);
        }
    }
}