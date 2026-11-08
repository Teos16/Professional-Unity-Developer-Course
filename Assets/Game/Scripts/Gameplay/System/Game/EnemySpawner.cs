using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class EnemySpawner : NetworkBehaviour
    {
        [SerializeField] private NetworkPrefabRef _enemyPrefab;
        [SerializeField] private SpawnPointService _spawnPointService;
        [SerializeField] private Transform _portal;

        private EnemyRegistry _enemyRegistry;

        public override void Spawned() => _enemyRegistry = GetBehaviour<EnemyRegistry>();

        public void Spawn()
        {
            Transform spawnPoint = _spawnPointService.GetRandomSpawnPoint();
            NetworkObject enemy = Runner.Spawn(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemy.GetBehaviour<EnemyController>().SetTarget(_portal.transform);
            _enemyRegistry.Register(enemy);
        }
    }
}
