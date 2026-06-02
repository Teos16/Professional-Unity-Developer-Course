using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public static class WeaponUseCase
    {
        public static bool CollectAmmo(this IEntity character, int amount)
        {
            IEntity weapon = character.GetWeapon().Value;
            if (weapon == null || !weapon.TryGetAmmo(out IVariable<int> ammo))
                return false;
            
            ammo.Value += amount;
            return true;
        }
        
        public static bool PickUpWeapon(this IEntity character, IEntity pickUp)
        {
            IVariable<IEntity> weaponVariable = character.GetWeapon();
            if (weaponVariable.Value != null)
                return false;

            SceneEntity weaponPrefab = pickUp.GetWeaponPrefab();
            Transform parent = character.GetTransform();
            
            SceneEntity weaponEntity = SceneEntity.Create(weaponPrefab, parent.position, parent.rotation, parent);
            
            if(pickUp.TryGetHealth(out IReactiveVariable<int> health))
                weaponEntity.GetHealth().Value = health.Value;
             
            if(pickUp.TryGetAmmo(out IVariable<int> ammo))
                weaponEntity.GetAmmo().Value = ammo.Value;
            
            weaponVariable.Value = weaponEntity;
             
            SceneEntity.Destroy(pickUp);
            return true;
        }
        
        public static bool DropWeapon(this IEntity character)
         {
             IVariable<IEntity> weaponVariable = character.GetWeapon();
             IEntity weapon = weaponVariable.Value;

             if (weapon == null)
                 return false;

             SceneEntity pickUpPrefab = weapon.GetPickUpPrefab();

             Vector3 spawnPosition = character.GetPosition().Value;
             Quaternion spawnRotation = character.GetRotation().Value;
             
             SceneEntity pickUpEntity = SceneEntity.Create(pickUpPrefab, spawnPosition, spawnRotation);
             
             if(weapon.TryGetHealth(out IReactiveVariable<int> health))
                 pickUpEntity.GetHealth().Value = health.Value;
             
             if(weapon.TryGetAmmo(out IVariable<int> ammo))
                 pickUpEntity.GetAmmo().Value = ammo.Value;
             
             weaponVariable.Value = null;
             SceneEntity.Destroy(weapon);
             return true;
         }
    }
}