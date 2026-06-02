// using Atomic.Elements;
// using Atomic.Entities;
// using Game;
// using UnityEngine;
//
// namespace Game
// {
//     public static class MoveUseCase
//     {
//         public static void MoveStep(this IEntity entity, Vector3 direction, float deltaTime)
//         {
//             IVariable<Vector3> position = entity.GetPosition();
//             float speed = entity.GetMoveSpeed().Value;
//             position.Value += direction * speed * deltaTime;
//         }
//     }
// }