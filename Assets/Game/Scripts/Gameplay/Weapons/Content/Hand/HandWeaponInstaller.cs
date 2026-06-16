using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class HandWeaponInstaller : WeaponInstaller
    {
        [BoxGroup("SPECIFIC"), SerializeField] private GameEntity _owner;
        [BoxGroup("SPECIFIC"), SerializeField] private Const<int> _damage = 1;
        [BoxGroup("SPECIFIC"),SerializeField] private Const<float> _attackDistance = 1.5f;
        
        public override void Install(IWeaponEntity weapon)
        {
            base.Install(weapon);
            
            weapon.AddValue(WeaponEntityAPI.Owner, _owner);
            weapon.AddValue(WeaponEntityAPI.Damage, _damage);
            weapon.AddValue(WeaponEntityAPI.AttackDistance, _attackDistance);
            weapon.GetValue(WeaponEntityAPI.AttackCommand)
                .AddCondition(weapon.IsTargetCloseToOwner)
                .AddAction(() =>
                {
                    IGameEntity target = _owner.GetValue(GameEntityAPI.Target).Value;
                    target.TakeDamage(_damage.Value, _teamType);
                });
        }
    }
}