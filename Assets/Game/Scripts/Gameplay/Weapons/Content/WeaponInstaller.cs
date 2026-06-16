using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    public class WeaponInstaller : WeaponEntityInstaller
    {
        [BoxGroup("BASE"), SerializeField] protected TeamType _teamType;
        [BoxGroup("BASE"), SerializeField] private Cooldown _cooldown = 1;

        public override void Install(IWeaponEntity weapon)
        {
            // Attack Command
            weapon.AddValue(WeaponEntityAPI.AttackCommand, new Command());
            
            // Cooldown
            weapon.AddValue(WeaponEntityAPI.AttackCooldown, _cooldown);
            weapon.GetValue(WeaponEntityAPI.AttackCommand)
                .AddCondition(_cooldown.IsCompleted)
                .AddAction(_cooldown.ResetTime);
            weapon.WhenFixedTick(_cooldown.Tick);
        }
    }
}