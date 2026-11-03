using System.Linq;
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
        [SerializeField] private GameState _gameState;

        [Networked] private int _spawnedEnemyCount { get; set; }
        [Networked] private TickTimer _timestamp { get; set; }

        public override void FixedUpdateNetwork()
        {
            if(!HasStateAuthority)
                return;
            
            if(Runner.ActivePlayers.Count() != 2)
                return;
            
            if (_timestamp.IsRunning(this.Runner))
                return;
            
            if (_spawnedEnemyCount >= _enemyCountToSpawn)
                return;

            Transform spawnPoint = _spawnPointService.GetRandomSpawnPoint();
            NetworkObject enemy = Runner.Spawn(_enemyConfig.Prefab, spawnPoint.position, spawnPoint.rotation);
            enemy.GetBehaviour<EnemyController>().SetTarget(_portal.transform);
            _timestamp = TickTimer.CreateFromSeconds(this.Runner, _spawnInterval);
            _spawnedEnemyCount++;
        }
    }
}