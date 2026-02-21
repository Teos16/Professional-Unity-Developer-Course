using System;
using System.Collections.Generic;
using Game.ShipRelated;
using UnityEngine;

namespace Game.Enemy
{
    public sealed class EnemyManager : MonoBehaviour
    {
        public event Action<int> OnDestroyedEnemiesCountChanged;
        
        [SerializeField] private EnemySpawnConfig _spawnConfig;
        [SerializeField] private PositionService _spawnPositions;
        [SerializeField] private PositionService _attackPositions;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Ship _playerShip;
        [SerializeField] private CooldownTimer _spawnCooldownTimer;
        
        private readonly List<GameObject> _activeEnemies = new();
        
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
            GameObject enemy = _enemySpawner.Spawn();
            enemy.GetComponent<EnemyBehaviour>().SetPosition(_spawnPositions.Next());
            enemy.GetComponent<EnemyBehaviour>().SetDestination(_attackPositions.Next());
            enemy.GetComponent<Ship>().OnDeath += OnEnemyDeath;
            _activeEnemies.Add(enemy);
            
            enemy.gameObject.SetActive(true);
        }

        private void OnEnemyDeath(GameObject ship)
        {
            ship.GetComponent<Ship>().OnDeath -= OnEnemyDeath;
            _activeEnemies.Remove(ship.gameObject);
            _destroyedEnemiesCount++;
            OnDestroyedEnemiesCountChanged?.Invoke(_destroyedEnemiesCount);
            _enemySpawner.Despawn(ship.gameObject);
        }

        private bool CanSpawnEnemy() => _spawnCooldownTimer.IsReady() && _playerShip.IsAlive();
    }
}