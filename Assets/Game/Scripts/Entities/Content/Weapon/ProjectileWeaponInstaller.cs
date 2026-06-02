using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileWeaponInstaller : WeaponInstaller
    {
        [SerializeField] private Transform _firePoint;
        
        public override void Install(IEntity entity)
        {
            base.Install(entity);
            entity.GetFireAction()
                .Add(() => GameContext.Instance.SpawnBullet(_firePoint.position, _firePoint.rotation));
        }
    }
}