// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public abstract class WeaponInstaller : SceneEntityInstaller
//     {
//         [SerializeField]
//         private FireInstaller _fireInstaller;
//         
//         [SerializeField]
//         private Optional<Cooldown> _fireCooldown;
//
//         [SerializeField]
//         private Optional<Variable<int>> _ammo;
//
//         [SerializeField]
//         private SceneEntity _pickUpPrefab;
//         
//         public override void Install(IEntity entity)
//         {
//             _fireInstaller.Install(entity);
//             
//             if (_fireCooldown)
//             {
//                 entity.GetFireCondition().Add(_fireCooldown.Value.IsCompleted);
//                 entity.GetFireAction().Add(_fireCooldown.Value.ResetTime);
//                 entity.WhenFixedTick(_fireCooldown.Value.Tick);
//             }
//
//             if (_ammo)
//             {
//                 entity.AddAmmo(_ammo.Value);
//                 entity.GetFireCondition().Add(() => entity.GetAmmo().Value > 0);
//                 entity.GetFireAction().Add(() => entity.GetAmmo().Value -= 1);
//             }
//             
//             entity.AddPickUpPrefab(_pickUpPrefab);
//         }
//     }
// }