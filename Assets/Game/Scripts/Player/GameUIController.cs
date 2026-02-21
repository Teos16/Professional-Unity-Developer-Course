using Game.Enemy;
using Game.ShipRelated;
using Modules.UI;
using UnityEngine;

namespace Game.UI
{
    public sealed class GameUIController : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private ScoreView _scoreView;

        [Header("Dependencies")]
        [SerializeField] private Ship _player;
        [SerializeField] private EnemyManager _enemyManager;

        private void Start()
        {
            _enemyManager.OnDestroyedEnemiesCountChanged += OnDestroyedEnemiesCountChanged;
            _player.OnDeath += OnDeath;
            _player.OnHealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _enemyManager.OnDestroyedEnemiesCountChanged -= OnDestroyedEnemiesCountChanged;
            _player.OnDeath -= OnDeath;
            _player.OnHealthChanged -= OnHealthChanged;
        }

        private void OnDestroyedEnemiesCountChanged(int count) => _scoreView.SetValue(count);
        
        private void OnHealthChanged(int health, int maxHealth) => _healthView.SetHealth(health, maxHealth);

        private void OnDeath(GameObject _) => _gameOverView.Show();
    }
}