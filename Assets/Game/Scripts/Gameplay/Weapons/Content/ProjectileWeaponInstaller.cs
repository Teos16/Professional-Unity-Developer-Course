using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ProjectileWeaponInstaller : WeaponInstaller
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private EffectConfig _effectConfig;

        public override void Install(IWeaponEntity entity)
        {
            base.Install(entity);

            GameContext gameContext = GameContext.Instance;
            entity.GetFireCommand().AddAction(() =>
            {
                IGameEntity owner = entity.GetOwner().Value;
                TeamType team = owner.GetTeam().Value;
                
                IGameEntity bullet = gameContext.SpawnBullet(_firePoint.position, _firePoint.rotation, team);
                bullet.GetDamageMultiplier().CopyFrom(owner.GetDamageMultiplier());
                bullet.GetEffect().Value = _effectConfig;
            });
        }
    }
}