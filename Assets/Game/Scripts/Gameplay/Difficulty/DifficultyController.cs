using System;
using Modules;
using Zenject;

namespace Game
{
    public sealed class DifficultyController : IInitializable, IDisposable
    {
        private readonly CoinManager _coinManager;
        private readonly IDifficulty _difficulty;
        private readonly GameCycle _gameCycle;

        public DifficultyController(CoinManager coinManager, IDifficulty difficulty, GameCycle gameCycle)
        {
            _coinManager = coinManager;
            _difficulty = difficulty;
            _gameCycle = gameCycle;
        }

        public void Initialize()
        {
            _coinManager.OnAllCoinsPickedUp += ProceedToNextDifficulty;
            ProceedToNextDifficulty();
        }

        public void Dispose() => _coinManager.OnAllCoinsPickedUp -= ProceedToNextDifficulty;

        private void ProceedToNextDifficulty()
        {
            if (!_difficulty.Next(out int _)) 
                _gameCycle.Win();
        }
    }
}