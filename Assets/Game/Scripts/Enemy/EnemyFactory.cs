using Game.Bullets;
using Game.Ships;
using UnityEngine;

namespace Game.Enemy
{
    public sealed class EnemyFactory : Factory<EnemyBehaviour>
    {
        [SerializeField] private Ship _target;
        [SerializeField] private BulletPool _bulletPool;

        protected override void Setup(EnemyBehaviour instance)
        {
            instance.GetComponent<EnemyBehaviour>()?.Construct(_target);
            instance.GetComponent<WeaponComponent>()?.Construct(_bulletPool);
        }
    }
}