using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Enemy
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Pool _enemyPool;
        
        public GameObject Spawn() => _enemyPool.Rent();

        public void Despawn(GameObject enemy)
        {
            enemy.gameObject.SetActive(false);
            _enemyPool.Return(enemy);
        }
    }
}