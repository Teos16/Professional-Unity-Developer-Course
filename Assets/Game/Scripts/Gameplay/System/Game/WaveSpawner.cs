using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class WaveSpawner : NetworkBehaviour
    {
        [SerializeField] private float _spawnInterval;
        [SerializeField] private int _enemyCountToSpawn;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private SpawnPointService _spawnPointService;
        [SerializeField] private Transform _portal;

        [Networked] private NetworkBool _isRunning { get; set; }
        [Networked] private int _spawnedEnemyCount { get; set; }
        [Networked] private TickTimer _timestamp { get; set; }

        private List<Enemy> _enemies = new List<Enemy>();

        public override void FixedUpdateNetwork()
        {
            if(!HasStateAuthority)
                return;
            
            if (!_isRunning)
                return;
            
            if (_timestamp.IsRunning(this.Runner))
                return;
            
            if (_spawnedEnemyCount >= _enemyCountToSpawn)
                return;

            SpawnEnemy();
        }

        public void StartWave() => _isRunning = true;

        public void StopWave() => _isRunning = false;

        public bool IsFinished => _spawnedEnemyCount >= _enemyCountToSpawn;

        public bool AreAllEnemiesDead()
        {
            _enemies.RemoveAll(e => e == null || !e.Object || !e.Object.IsValid);
            return _enemies.Count == 0;
        }

        private void SpawnEnemy()
        {
            Transform spawnPoint = _spawnPointService.GetRandomSpawnPoint();
            NetworkObject enemy = Runner.Spawn(_enemyConfig.Prefab, spawnPoint.position, spawnPoint.rotation);
            enemy.GetBehaviour<EnemyController>().SetTarget(_portal.transform);
            _enemies.Add(enemy.GetBehaviour<Enemy>());
            _timestamp = TickTimer.CreateFromSeconds(this.Runner, _spawnInterval);
            _spawnedEnemyCount++;
        }
    }
}