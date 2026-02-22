using Game.Enemy;
using Game.Ships;
using UnityEngine;

namespace Game.Enemy
{
    public sealed class EnemyFactory : Factory
    {
        [SerializeField] private Ship _target;
        [SerializeField] private Pool _bulletPool;

        protected override void Setup(GameObject instance)
        {
            instance.GetComponent<EnemyBehaviour>()?.Construct(_target);
            instance.GetComponent<AimedFireDirection>()?.Construct(_target);
            instance.GetComponent<WeaponComponent>()?.Construct(_bulletPool);
        }
    }
}