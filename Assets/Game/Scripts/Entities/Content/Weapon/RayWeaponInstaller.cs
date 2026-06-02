using Atomic.Entities;
using Game;
using UnityEngine;

namespace SampleGame
{
    public sealed class RayWeaponInstaller : WeaponInstaller
    {
        [SerializeField] private float _distance = 100f;
        [SerializeField] private int _damage = 25;
        [SerializeField] private LayerMask _hitMask;
        [SerializeField] private Transform _firePoint;

        public override void Install(IEntity entity)
        {
            base.Install(entity);
            entity.GetFireAction().Add(() =>
            {
                CombatUseCase.RayDamage(_firePoint.position, _firePoint.forward, _distance, _hitMask, _damage);
                Debug.Log("PEW!");
            });
        }
    }
}