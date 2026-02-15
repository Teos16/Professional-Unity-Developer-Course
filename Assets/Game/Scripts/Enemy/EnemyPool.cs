using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public sealed class EnemyPool : MonoBehaviour
    {
        private const int POOL_CAPACITY = 10;
        
        [SerializeField] private EnemyFactory _factory;

        private readonly Stack<EnemyShipAIController> _pool = new();
        
        private void Start()
        {
            for (int i = 0; i < POOL_CAPACITY; i++) 
                SpawnDefaultEnemies();
        }

        private void SpawnDefaultEnemies()
        {
            EnemyShipAIController bullet = _factory.SpawnEnemy(); 
            bullet.gameObject.SetActive(false);
            _pool.Push(bullet);
        }

        public EnemyShipAIController Rent()
        {
            if (_pool.TryPop(out EnemyShipAIController enemy))
                return enemy;
            
            return _factory.SpawnEnemy();
        }

        public void Return(EnemyShipAIController enemy)
        {
            enemy.gameObject.SetActive(false);
            _pool.Push(enemy);
        }
    }
}