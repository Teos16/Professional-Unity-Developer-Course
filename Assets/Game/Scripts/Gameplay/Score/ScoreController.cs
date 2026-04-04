using System;
using Modules;
using Zenject;

namespace Game
{
    public sealed class ScoreController : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly CoinManager _coinManager;

        public ScoreController(IScore score, CoinManager coinManager)
        {
            _score = score;
            _coinManager = coinManager;
        }

        public void Initialize() => _coinManager.OnCoinPickedUp += ExpandSnake;

        public void Dispose() => _coinManager.OnCoinPickedUp -= ExpandSnake;

        private void ExpandSnake(ICoin coin) => _score.Add(coin.Score);
    }
}