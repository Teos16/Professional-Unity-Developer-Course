// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
// using Zenject;
//
// namespace Game
// {
//     public static class WeaponUseCase
//     {
//         public static bool CollectAmmo(this IEntity character, int amount)
//         {
//             IEntity weapon = character.GetWeapon().Value;
//             if (weapon == null || !weapon.TryGetAmmo(out IVariable<int> ammo))
//                 return false;
//
//             ammo.Value += amount;
//             return true;
//         }
//
//         public static bool PickUpWeapon(this SceneEntity character, IEntity pickUp, DiContainer container)
//         {
//             IVariable<IEntity> weaponVariable = character.GetWeapon();
//             if (weaponVariable.Value != null)
//                 return false;
//
//             SceneEntity weaponPrefab = pickUp.GetWeaponPrefab();
//             Transform parent = character.transform;
//             
//             ItemEntityPool entityPool = container.Resolve<ItemEntityPool>();
//             SceneEntity weaponEntity = entityPool.Rent(weaponPrefab, parent.position, parent.rotation, parent);
//
//             weaponEntity.GetAmmo().Value = pickUp.GetAmmo().Value;
//             weaponVariable.Value = weaponEntity;
//             
//             entityPool.Return((SceneEntity) pickUp);
//             return true;
//         }
//
//         public static bool DropWeapon(this SceneEntity character, DiContainer container)
//         {
//             IVariable<IEntity> weaponVariable = character.GetWeapon();
//             IEntity weapon = weaponVariable.Value;
//
//             if (weapon == null)
//                 return false;
//
//             SceneEntity pickUpPrefab = weapon.GetPickUpPrefab();
//             Transform characterTransform = character.transform;
//
//             Vector3 spawnPosition = characterTransform.position;
//             Quaternion spawnRotation = characterTransform.rotation;
//             
//             SceneEntity pickUpEntity = SceneEntity.Create(pickUpPrefab, spawnPosition, spawnRotation);
//             pickUpEntity.GetAmmo().Value = weapon.GetAmmo().Value;
//             
//             weaponVariable.Value = null;
//             SceneEntity.Destroy(weapon);
//             return true;
//         }
//     }
// }