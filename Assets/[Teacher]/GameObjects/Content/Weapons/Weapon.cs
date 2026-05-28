// using Atomic.Elements;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class Weapon : MonoBehaviour
//     {
//         private FireRequestComponent _fireRequestComponent;
//
//         [SerializeField]
//         private Optional<FireComponentBase> _fireComponent;
//
//         [SerializeField]
//         private Optional<CooldownComponent> _cooldownComponent;
//
//         [SerializeField]
//         private Optional<AmmoComponent> _ammoComponent;
//
//         private void Awake()
//         {
//             _fireRequestComponent = this.GetComponent<FireRequestComponent>();
//             _cooldownComponent = this.GetComponent<CooldownComponent>();
//             _ammoComponent = this.GetComponent<AmmoComponent>();
//             
//             _fireRequestComponent.SetCondition(() => (!_ammoComponent.Active || _ammoComponent.Value.HasAmmo) &&
//                                                      (!_cooldownComponent.Active || _cooldownComponent.Value.IsExpired));
//             _fireRequestComponent.SetAction(() =>
//             {
//                 if (_fireComponent) _fireComponent.Value.Fire();
//                 if (_ammoComponent) _ammoComponent.Value.UseAmmo(1);
//                 if (_cooldownComponent) _cooldownComponent.Value.Reset();
//             });
//         }
//     }
// }