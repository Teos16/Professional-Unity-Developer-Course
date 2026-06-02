// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game
// {
//     public static class RotateUseCase
//     {
//         public static void RotateStep(this IEntity entity, Vector3 direction, float deltaTime)
//         {
//             if (direction == Vector3.zero)
//                 return;
//
//             IVariable<Quaternion> rotation = entity.GetRotation();
//             IValue<float> speed = entity.GetRotationSpeed();
//             Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
//             rotation.Value = Quaternion.RotateTowards(rotation.Value, targetRotation, speed.Value * deltaTime);
//         }
//     }
// }