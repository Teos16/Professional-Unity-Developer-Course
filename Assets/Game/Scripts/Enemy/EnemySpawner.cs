using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private PositionService _spawnPositions;
        [SerializeField] private PositionService _attackPositions;
        [SerializeField] private Pool _enemyPool;
        
        public EnemyBehaviour Spawn()
        {
            GameObject enemy = _enemyPool.Rent();
            EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            enemyBehaviour.SetPosition(_spawnPositions.Next());
            enemyBehaviour.SetDestination(_attackPositions.Next());
            enemy.gameObject.SetActive(true);
            return enemyBehaviour;
        }

        public void Despawn(GameObject enemy)
        {
            _enemyPool.Return(enemy.gameObject);
            enemy.SetActive(false);
        }
    }
}