using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace Game.Gameplay
{
    public class WeaponInstaller : WeaponEntityInstaller
    {
        [SerializeField]
        private Optional<Variable<int>> _ammo;

        [SerializeField]
        private Optional<ReactiveVariable<int>> _health;

        [SerializeField]
        private Optional<Cooldown> _cooldown;

        [SerializeField]
        private GameEntity _pickUpPrefab;

        public override void Install(IWeaponEntity entity)
        {
            entity.AddFireCondition(new AndExpression());
            entity.AddFireAction(new CompositeAction());
            entity.AddFireEvent(new Event());

            var parameterKeys = new List<string>();
            entity.AddDynamicParameterNames(parameterKeys);
            
            if (_cooldown)
            {
                Cooldown cooldown = _cooldown.Value;
                entity.AddFireCooldown(cooldown);
                entity.GetFireCondition().Add(() => entity.GetFireCooldown().IsCompleted());
                entity.GetFireAction().Add(() => entity.GetFireCooldown().ResetTime());
                entity.WhenFixedTick(cooldown.Tick);
            }

            if (_ammo)
            {
                entity.AddAmmo(_ammo.Value);
                entity.GetFireCondition().Add(() => entity.GetAmmo().Value > 0);
                entity.GetFireAction().Add(() => entity.GetAmmo().Value--);
                parameterKeys.Add(nameof(GameEntityAPI.Ammo));
            }

            if (_health)
            {
                entity.AddHealth(_health.Value);
                entity.GetFireCondition().Add(() => entity.GetHealth().Value > 0);
                entity.GetFireAction().Add(() => entity.GetHealth().Value -= 3);
                parameterKeys.Add(nameof(GameEntityAPI.Health));
            }
            
            entity.AddPickUpPrefab(_pickUpPrefab);
        }
    }
}