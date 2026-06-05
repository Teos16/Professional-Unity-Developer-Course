using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ProjectileWeaponInstaller : WeaponInstaller
    {
        [SerializeField]
        private Transform _firePoint;

        public override void Install(IWeaponEntity entity)
        {
            base.Install(entity);
            entity.AddOwner(new Variable<IGameEntity>());

            GameContext gameContext = GameContext.Instance;
            entity.GetFireAction().Add(() =>
            {
                TeamType team = entity.GetOwner().Value.GetTeam().Value;
                gameContext.SpawnBullet(_firePoint.position, _firePoint.rotation, team);
            });
        }
    }
}