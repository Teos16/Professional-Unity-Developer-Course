using System;
using Modules;
using SnakeGame;
using Zenject;

namespace Game
{
    public sealed class GameUIController : IInitializable, IDisposable
    {
        private IGameUI _gameUI;
        private IDifficulty _difficulty;
        private IScore _score;
        private DeathHandler _deathHandler;
        private Progression _progression;

        public GameUIController(IGameUI gameUI, IDifficulty difficulty, IScore score, 
            DeathHandler deathHandler, Progression progression)
        {
            _gameUI = gameUI;
            _difficulty = difficulty;
            _score = score;
            _deathHandler = deathHandler;
            _progression = progression;
        }
        
        public void Initialize()
        {
            DisplayScore(_score.Current);
            DisplayDifficulty();
            
            _difficulty.OnStateChanged += DisplayDifficulty;
            _score.OnStateChanged += DisplayScore;
            _deathHandler.OnDeath += DisplayGameOverOnDeath;
            _progression.OnVictory += DisplayGameOverOnVictory;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= DisplayDifficulty;
            _score.OnStateChanged -= DisplayScore;
            _deathHandler.OnDeath -= DisplayGameOverOnDeath;
            _progression.OnVictory -= DisplayGameOverOnVictory;
        }

        private void DisplayDifficulty() => _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);

        private void DisplayScore(int score) => _gameUI.SetScore(score.ToString());
        
        private void DisplayGameOverOnDeath() => _gameUI.GameOver(false);
        
        private void DisplayGameOverOnVictory() => _gameUI.GameOver(true);
    }
}