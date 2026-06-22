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
        [BoxGroup("SPECIFIC"), SerializeField] private Const<float> _attackDistance = 1f;
        [BoxGroup("SPECIFIC"), SerializeField] private LayerMask _layerMask;
        
        public override void Install(IWeaponEntity weapon)
        {
            base.Install(weapon);
            
            GameContext gameContext = GameContext.Instance;
            
            weapon.AddValue(WeaponEntityAPI.Owner, _owner);
            weapon.AddValue(WeaponEntityAPI.Damage, _damage);
            weapon.AddValue(WeaponEntityAPI.AttackDistance, _attackDistance);
            weapon.GetValue(WeaponEntityAPI.AttackCommand)
                .AddCondition(() => _owner.CanAttackCloseTarget(_attackDistance.Value, _layerMask))
                .AddAction(() =>
                {
                    _owner.AttackTarget(gameContext, _damage.Value, _teamType);
                });
        }
    }
}