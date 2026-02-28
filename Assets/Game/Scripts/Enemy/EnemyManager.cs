using System;
using Game.Ships;
using UnityEngine;

namespace Game.Enemy
{
    public sealed class EnemyManager : MonoBehaviour
    {
        public event Action<int> OnDestroyedEnemiesCountChanged;
        
        [SerializeField] private EnemySpawnConfig _spawnConfig;
        [SerializeField] private Ship _playerShip;
        [SerializeField] private CooldownTimer _spawnCooldownTimer;
        [SerializeField] private EnemySpawner _enemySpawner;
        
        private int _destroyedEnemiesCount;
        
        private void Start()
        {
            _spawnCooldownTimer.SetCooldownLimits(_spawnConfig.MinSpawnCooldown, _spawnConfig.MaxSpawnCooldown);
            OnDestroyedEnemiesCountChanged?.Invoke(_destroyedEnemiesCount);
        }

        private void FixedUpdate()
        {
            if (!CanSpawnEnemy())
                return;

            CreateEnemy();
            _spawnCooldownTimer.Reset();
        }

        private void CreateEnemy()
        {
            EnemyBehaviour enemyBehaviour = _enemySpawner.Spawn();
            enemyBehaviour.GetComponent<Ship>().OnDeath += OnEnemyDeath;
        }

        private void OnEnemyDeath(GameObject ship)
        {
            ship.GetComponent<Ship>().OnDeath -= OnEnemyDeath;
            _enemySpawner.Despawn(ship.GetComponent<EnemyBehaviour>());
            _destroyedEnemiesCount++;
            OnDestroyedEnemiesCountChanged?.Invoke(_destroyedEnemiesCount);
        }

        private bool CanSpawnEnemy() => _spawnCooldownTimer.IsReady() && _playerShip.IsAlive();
    }
}