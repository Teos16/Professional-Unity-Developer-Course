using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class WeaponInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField]
        private GameEntity _pickUpPrefab;
        
        [SerializeField]
        private Optional<Variable<int>> _ammo;

        [SerializeField]
        private Optional<ReactiveVariable<int>> _health;

        [SerializeField]
        private Optional<Cooldown> _cooldown;
        
        public override void Install(IWeaponEntity entity)
        {
            entity.AddFireCommand(new Command());
            
            // Owner
            entity.AddOwner(new Variable<IGameEntity>());
            entity.GetFireCommand().AddCondition(() => entity.GetOwner().Value != null);
            
            entity.AddPickUpPrefab(_pickUpPrefab);
            
            List<string> parameterKeys = new List<string>();
            entity.AddDynamicParameterNames(parameterKeys);
            
            if (_cooldown)
            {
                ICooldown cooldown = _cooldown.Value;
                entity.AddFireCooldown(cooldown);
                entity.GetFireCommand().AddCondition(cooldown.IsCompleted);
                entity.GetFireCommand().AddAction(cooldown.ResetTime);
                entity.WhenFixedTick(cooldown.Tick);
            }

            if (_ammo)
            {
                IVariable<int> ammo = _ammo.Value;
                entity.AddAmmo(ammo);
                entity.GetFireCommand().AddCondition(() => ammo.Value > 0);
                entity.GetFireCommand().AddAction(() => ammo.Value--);
                parameterKeys.Add(nameof(GameEntityAPI.Ammo));
            }

            if (_health)
            {
                entity.AddHealth(_health.Value);
                entity.GetFireCommand().AddCondition(() => entity.GetHealth().Value > 0);
                entity.GetFireCommand().AddAction(() => entity.GetHealth().Value -= 3);
                parameterKeys.Add(nameof(GameEntityAPI.Health));
            }
            
        }
    }
}