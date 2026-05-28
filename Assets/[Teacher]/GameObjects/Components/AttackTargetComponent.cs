// using System;
// using UnityEngine;
//
// namespace SampleGame
// {
//     [RequireComponent(typeof(TargetComponent), typeof(FireRequestComponent))]
//     public sealed class AttackTargetComponent : MonoBehaviour
//     {
//         private Func<bool> _condition;
//         private Action _action;
//         
//         private TargetComponent _targetComponent;
//         private FireRequestComponent _fireRequestComponent;
//
//         private void Awake()
//         {
//             _targetComponent = this.GetComponent<TargetComponent>();
//             _fireRequestComponent = this.GetComponent<FireRequestComponent>();
//         }
//
//         public void SetCondition(Func<bool> condition) => _condition = condition;
//
//         private void Update()
//         {
//             if (_condition == null || _condition.Invoke()) 
//                 this.Attack();
//         }
//
//         private void Attack()
//         {
//             GameObject target = _targetComponent.Target;
//             if (target == null || !target.TryGetComponent(out HealthComponent health) || !health.IsAlive())
//                 return;
//
//             _action?.Invoke();
//             _fireRequestComponent.Fire();
//         }
//     }
// }