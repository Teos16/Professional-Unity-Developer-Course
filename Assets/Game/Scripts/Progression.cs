using System;
using Modules;
using Zenject;

namespace Game
{
    public sealed class Progression : IInitializable, IDisposable
    {
        public event Action OnVictory;
        
        private IDifficulty _difficulty;
        private ISnake _snake;
        private CoinManager _coinManager;

        private int _level;

        public Progression(IDifficulty difficulty, CoinManager coinManager, ISnake snake)
        {
            _difficulty = difficulty;
            _coinManager = coinManager;
            _snake = snake;
        }

        public void Initialize()
        {
            _coinManager.OnAllCoinsPickedUp += ProceedToNextDifficulty;
            ProceedToNextDifficulty();
        }

        public void Dispose()
        {
            _coinManager.OnAllCoinsPickedUp -= ProceedToNextDifficulty;
        }

        private void ProceedToNextDifficulty()
        {
            if (_difficulty.Next(out int level))
            {
                _coinManager.SpawnCoins(level);
                _snake.SetSpeed(level);
            }
            else
                OnVictory?.Invoke();
        }
    }
}