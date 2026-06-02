// using Atomic.Entities;
// using UnityEngine;
// using Zenject;
//
// namespace SampleGame
// {
//     public static class CombatUseCase
//     {
//         public static void RayDamage(Vector3 position, Vector3 direction, float distance, LayerMask layerMask, int damage)
//         {
//             if (!Physics.Raycast(position, direction, out RaycastHit hit, distance, layerMask))
//                 return;
//
//             if (hit.collider.TryGetComponent(out IEntity entity) && entity.HasDamageableTag()) 
//                 entity.GetTakeDamageAction().Invoke(damage);
//         }
//
//         public static void SpawnBullet(this DiContainer gameContext, Vector3 position, Quaternion rotation)
//         {
//             BulletPool bulletPool = gameContext.Resolve<BulletPool>();
//             SceneEntity bullet = bulletPool.Rent();
//             bullet.GetRespawnAction().Invoke();
//             bullet.GetPosition().Value = position;
//             bullet.GetRotation().Value = rotation;
//         }
//
//         public static void DespawnBullet(this DiContainer gameContext, SceneEntity bullet)
//         {
//             BulletPool bulletPool = gameContext.Resolve<BulletPool>();
//             bulletPool.Return(bullet);
//         }
//     }
// }