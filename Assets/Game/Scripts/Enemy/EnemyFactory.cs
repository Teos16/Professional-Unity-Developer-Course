using Game.Bullet;
using Game.ShipRelated;
using UnityEngine;

namespace Game.Enemy
{
    public sealed class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyShipAIController _prefab;
        [SerializeField] private Transform _container;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private Ship _target;

        public EnemyShipAIController SpawnEnemy()
        {
            EnemyShipAIController enemy = Instantiate(_prefab, _container);
            enemy.GetComponent<AimedBulletCreator>()?.Initialize(_bulletPool, _target);
            enemy.gameObject.SetActive(false);
            return enemy;
        }
    }
}