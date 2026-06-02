using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class WeaponPickUpInstaller : PickUpInstaller
    {
        [SerializeField] private SceneEntity _weaponPrefab;
        [SerializeField] private Variable<int> _ammo = 10;
        [SerializeField] private ReactiveVariable<int> _health = 1000;
        
        public override void Install(IEntity entity)
        {
            base.Install(entity);
            
            entity.GetInteractCondition().Add(target => target.HasCharacterTag());
            entity.GetInteractAction().Add(target => target.PickUpWeapon(entity));
            
            entity.AddWeaponPrefab(_weaponPrefab);
            entity.AddAmmo(_ammo);
            entity.AddHealth(_health);
        }
    }
}