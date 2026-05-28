// using UnityEngine;
//
// namespace SampleGame
// {
//     [RequireComponent(typeof(FireRequestComponent), typeof(FireBulletComponent), typeof(CooldownComponent))]
//     [RequireComponent(typeof(AttackTargetComponent), typeof(RotateAtTargetComponent), typeof(HealthComponent))]
//     public sealed class Tower : MonoBehaviour
//     {
//         private FireRequestComponent _fireRequestComponent;
//         private FireBulletComponent _fireBulletComponent;
//         private CooldownComponent _cooldownComponent;
//         private AttackTargetComponent _attackTargetComponent;
//         private RotateAtTargetComponent _rotateTargetComponent;
//         private HealthComponent _healthComponent;
//
//         private void Awake()
//         {
//             _fireRequestComponent = this.GetComponent<FireRequestComponent>();
//             _healthComponent = this.GetComponent<HealthComponent>();
//             _fireBulletComponent = this.GetComponent<FireBulletComponent>();
//             _cooldownComponent = this.GetComponent<CooldownComponent>();
//             _attackTargetComponent = this.GetComponent<AttackTargetComponent>();
//             _rotateTargetComponent = this.GetComponent<RotateAtTargetComponent>();
//             
//             
//             _attackTargetComponent.SetCondition(_healthComponent.IsAlive);
//             _rotateTargetComponent.SetCondition(_healthComponent.IsAlive);
//             
//             _fireRequestComponent.SetCondition(() => _cooldownComponent.IsExpired);
//             _fireRequestComponent.SetAction(() =>
//             {
//                 _fireBulletComponent.Fire();
//                 _cooldownComponent.Reset();
//             });
//         }
//         
//         private void OnEnable()
//         {
//             _healthComponent.OnHealthEmpty += this.OnHealthEmpty;
//         }
//
//         private void OnDisable()
//         {
//             _healthComponent.OnHealthEmpty -= this.OnHealthEmpty;
//         }
//
//         private void OnHealthEmpty() => Destroy(this.gameObject);
//     }
// }