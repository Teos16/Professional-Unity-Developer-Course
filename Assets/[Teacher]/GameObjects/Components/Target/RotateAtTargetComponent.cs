// using System;
// using UnityEngine;
//
// namespace SampleGame
// {
//     [RequireComponent(typeof(TargetComponent), typeof(RotateComponent))]
//     public sealed class RotateAtTargetComponent : MonoBehaviour
//     {
//         public Func<bool> _condition;
//         
//         private TargetComponent _targetComponent;
//         private RotateComponent _rotateComponent;
//
//         private void Awake()
//         {
//             _targetComponent = this.GetComponent<TargetComponent>();
//             _rotateComponent = this.GetComponent<RotateComponent>();
//         }
//
//         public void SetCondition(Func<bool> condition) => _condition = condition;
//
//         private void FixedUpdate()
//         {
//             if (_condition == null || _condition.Invoke()) 
//                 this.Rotate();
//         }
//
//         private void Rotate()
//         {
//             GameObject target = _targetComponent.Target;
//             if (target == null || !target.TryGetComponent(out HealthComponent health) || !health.IsAlive())
//                 return;
//
//             _rotateComponent.RotateTowards(target.transform);
//         }
//     }
// }