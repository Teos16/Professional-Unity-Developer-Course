// using System;
// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game
// {
//     [Serializable]
//     public sealed class MoveInstaller : IEntityInstaller
//     {
//         [SerializeField]
//         private Variable<float> _moveSpeed;
//
//         [SerializeField]
//         private Const<float> _moveDuration = 0.1f;
//         
//         public void Install(IEntity entity)
//         {
//             entity.AddMoveableTag();
//             entity.AddMoveSpeed(_moveSpeed);
//             entity.AddMoveRequest(new Request<Vector3>());
//             entity.AddMoveCondition(new AndExpression());
//             entity.AddMoveAction(new CompositeAction<Vector3, float>());
//             entity.AddMoveEvent(new Event<Vector3>());
//             entity.AddBehaviour<MoveBehaviour>();
//         }
//     }
// }