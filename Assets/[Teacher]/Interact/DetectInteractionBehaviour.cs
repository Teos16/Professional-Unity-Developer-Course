// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class DetectInteractionBehaviour : IEntityInit, IEntityFixedTick, IEntityGizmos
//     {
//         private IVariable<IEntity> _target;
//
//         private readonly Transform _center;
//         private readonly float _radius;
//         private readonly LayerMask _layerMask;
//         private readonly Cooldown _period;
//
//         public DetectInteractionBehaviour(
//             Transform center,
//             float radius,
//             LayerMask layerMask,
//             Cooldown period
//         )
//         {
//             _center = center;
//             _radius = radius;
//             _layerMask = layerMask;
//             _period = period;
//         }
//
//         public void Init(IEntity entity)
//         {
//             _target = entity.GetTargetInteractible();
//         }
//
//         public void FixedTick(IEntity entity, float deltaTime)
//         {
//             _period.Tick(deltaTime);
//             if (!_period.IsCompleted())
//                 return;
//
//             InteractUseCase.FindClosest(_center.position, _radius, _layerMask, out IEntity target);
//
//             if (target != null) 
//                 Debug.Log($"FOUND {target.Name}");
//             _target.Value = target;
//             _period.ResetTime();
//         }
//
//         public void DrawGizmos(IEntity entity)
//         {
//             Gizmos.DrawWireSphere(_center.position, _radius);
//         }
//     }
// }