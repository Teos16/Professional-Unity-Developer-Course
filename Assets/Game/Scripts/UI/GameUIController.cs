using System;
using Modules;
using SnakeGame;
using Zenject;

namespace Game
{
    public sealed class GameUIController : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly IDifficulty _difficulty;
        private readonly IScore _score;
        private readonly GameCycle _gameCycle;

        public GameUIController(IGameUI gameUI, IDifficulty difficulty, IScore score, GameCycle gameCycle)
        {
            _gameUI = gameUI;
            _difficulty = difficulty;
            _score = score;
            _gameCycle = gameCycle;
        }
        
        public void Initialize()
        {
            DisplayScore(_score.Current);
            DisplayDifficulty();
            
            _difficulty.OnStateChanged += DisplayDifficulty;
            _score.OnStateChanged += DisplayScore;
            _gameCycle.OnDeath += DisplayGameOverOnDeath;
            _gameCycle.OnVictory += DisplayGameOverOnVictory;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= DisplayDifficulty;
            _score.OnStateChanged -= DisplayScore;
            _gameCycle.OnDeath -= DisplayGameOverOnDeath;
            _gameCycle.OnVictory -= DisplayGameOverOnVictory;
        }

        private void DisplayDifficulty() => _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);

        private void DisplayScore(int score) => _gameUI.SetScore(score.ToString());
        
        private void DisplayGameOverOnDeath() => _gameUI.GameOver(false);
        
        private void DisplayGameOverOnVictory() => _gameUI.GameOver(true);
    }
}