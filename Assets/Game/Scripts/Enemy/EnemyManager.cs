using System;
using System.Collections;
using System.Collections.Generic;
using Game.ShipRelated;
using Modules.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Enemy
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [Header("Enemy Spawn Settings")]
        [SerializeField] private EnemySpawnConfig _spawnConfig;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private Transform[] _spawnPositions;
        private readonly List<EnemyShipAIController> _activeEnemies = new();
        private float _spawnCooldown;
        private float _spawnTime;
        private int _spawnIndex;
        private float _minSpawnCooldown;
        private float _maxSpawnCooldown;

        [Header("Enemy Attack Variables")]
        [SerializeField] private Ship _playerShip;
        [SerializeField] private Transform[] _attackPositions;
        private int _attackIndex;
        private int _destroyedEnemies;
        
        public event Action<int> OnDestroyedEnemiesCountChanged;
        
        private void Awake()
        {
            _spawnPositions.Shuffle();
            _attackPositions.Shuffle();
            
            _minSpawnCooldown = _spawnConfig.MinSpawnCooldown;
            _maxSpawnCooldown = _spawnConfig.MaxSpawnCooldown;
            
            ResetSpawnCooldown();
        }

        private void Start() => OnDestroyedEnemiesCountChanged?.Invoke(_destroyedEnemies);

        private void FixedUpdate()
        {
            if (!SpawnIsReady() || !_playerShip.IsAlive())
                return;

            CreateEnemy();
            ResetSpawnCooldown();
        }

        private void LateUpdate()
        {
            for (int i = _activeEnemies.Count - 1; i >= 0; i--)
            {
                EnemyShipAIController enemy = _activeEnemies[i];
                if (enemy.IsDead)
                {
                    _activeEnemies.RemoveAt(i);
                    Despawn(enemy);
                }
            }
        }

        private void CreateEnemy()
        {
            EnemyShipAIController enemy = _enemyPool.Rent();
            enemy.gameObject.SetActive(true);
            enemy.Initialize(_playerShip, NextSpawnPosition(), NextDestination());
            _activeEnemies.Add(enemy);
        }

        private bool SpawnIsReady() => Time.fixedTime - _spawnTime > _spawnCooldown;

        private void ResetSpawnCooldown()
        {
            _spawnCooldown = Random.Range(_minSpawnCooldown, _maxSpawnCooldown);
            _spawnTime = Time.fixedTime;
        }

        private void Despawn(EnemyShipAIController enemyShipAIController)
        {
            _destroyedEnemies++;
            OnDestroyedEnemiesCountChanged?.Invoke(_destroyedEnemies);
            StartCoroutine(DespawnInNextFrame(enemyShipAIController));
        }

        private IEnumerator DespawnInNextFrame(EnemyShipAIController enemyShipAIController)
        {
            yield return null;
            enemyShipAIController.gameObject.SetActive(false);
            _enemyPool.Return(enemyShipAIController);
        }
        
        private Vector3 NextSpawnPosition() => _spawnPositions.Next(ref _spawnIndex);

        private Vector3 NextDestination() => _attackPositions.Next(ref _attackIndex);
    }
}