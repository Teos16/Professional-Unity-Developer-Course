using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class WaveManager : NetworkBehaviour
    {
        [SerializeField] private float _spawnInterval;
        [SerializeField] private int _enemyCountToSpawn;

        [Networked] private NetworkBool _isRunning { get; set; }
        [Networked] private int _spawnedEnemyCount { get; set; }
        [Networked] private TickTimer _timestamp { get; set; }

        private EnemySpawner _enemySpawner;

        public bool IsFinished => _spawnedEnemyCount >= _enemyCountToSpawn;

        public override void Spawned() => _enemySpawner = GetBehaviour<EnemySpawner>();

        public override void FixedUpdateNetwork()
        {
            if (!HasStateAuthority || !_isRunning || IsFinished || _timestamp.IsRunning(Runner))
                return;

            _enemySpawner.Spawn();
            _timestamp = TickTimer.CreateFromSeconds(Runner, _spawnInterval);
            _spawnedEnemyCount++;
        }

        public void StartWave() => _isRunning = true;

        public void StopWave() => _isRunning = false;
    }
}
