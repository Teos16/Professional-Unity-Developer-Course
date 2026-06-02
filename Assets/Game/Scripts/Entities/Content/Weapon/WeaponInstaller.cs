using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public abstract class WeaponInstaller : SceneEntityInstaller
    {
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private Optional<Variable<int>> _ammo;
        [SerializeField] private Optional<ReactiveVariable<int>> _hitPoints;
        [SerializeField] private Optional<Cooldown> _cooldown ;
        [SerializeField] private SceneEntity _pickUpPrefab;

        public override void Install(IEntity entity)
        {
            _fireInstaller.Install(entity);

            if (_ammo)
            {
                entity.AddAmmo(_ammo.Value);
                entity.GetFireCondition().Add(() => entity.GetAmmo().Value > 0);
                entity.GetFireAction().Add(() => entity.GetAmmo().Value--);
            }

            if (_hitPoints)
            {
                entity.AddHealth(_hitPoints.Value);
                entity.GetFireCondition().Add(entity.IsAlive);
                entity.GetFireAction().Add(() => entity.GetHealth().Value -= 3);
            }
            
            if (_cooldown)
            {
                entity.AddFireCooldown(_cooldown);
                entity.GetFireCondition().Add(() => entity.GetFireCooldown().IsCompleted());
                entity.GetFireAction().Add(() => entity.GetFireCooldown().ResetTime());
                entity.WhenFixedTick(_cooldown.Value.Tick);
            }
            
            entity.AddPickUpPrefab(_pickUpPrefab);
        }
    }
}