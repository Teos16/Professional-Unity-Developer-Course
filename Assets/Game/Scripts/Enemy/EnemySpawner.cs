using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private PositionService _spawnPositions;
        [SerializeField] private PositionService _attackPositions;
        [SerializeField] private EnemyPool _enemyPool;
        
        public EnemyBehaviour Spawn()
        {
            EnemyBehaviour enemy = _enemyPool.Rent();
            enemy.SetPosition(_spawnPositions.Next());
            enemy.SetDestination(_attackPositions.Next());
            return enemy;
        }

        public void Despawn(EnemyBehaviour enemy) => _enemyPool.Return(enemy);
    }
}