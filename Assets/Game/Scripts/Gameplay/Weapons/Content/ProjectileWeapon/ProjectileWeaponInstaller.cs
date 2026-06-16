using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    public class ProjectileWeaponInstaller : WeaponInstaller
    {
        [BoxGroup("SPECIFIC"), SerializeField] private Transform _firePoint;
        [BoxGroup("SPECIFIC"), SerializeField] private float _spreadAngle;
        [BoxGroup("SPECIFIC"), SerializeField] private ReactiveVariable<int> _ammo = 8;

        public override void Install(IWeaponEntity weapon)
        {
            base.Install(weapon);
            
            // Ammo
            IReactiveVariable<int> ammo = _ammo;
            weapon.AddValue(WeaponEntityAPI.Ammo, ammo);
            weapon.GetValue(WeaponEntityAPI.AttackCommand)
                .AddCondition(() => ammo.Value > 0)
                .AddAction(() => ammo.Value--);

            // Fire
            GameContext gameContext = GameContext.Instance;
            weapon.GetValue(WeaponEntityAPI.AttackCommand)
                .AddAction(() =>
                {
                    IGameEntity bullet = gameContext.SpawnBullet(_firePoint.position, _firePoint.rotation, _teamType);
                    bullet.SetRandomSpread(_spreadAngle);
                });
        }
    }
}