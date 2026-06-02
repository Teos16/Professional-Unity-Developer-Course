// using System.Buffers;
// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public static class InteractUseCase
//     {
//         public static void InteractWith(this IEntity interactor, IEntity target)
//         {
//             if (target != null && target.HasInteractibleTag() && target.GetInteractCondition().Invoke(interactor))
//             {
//                 target.GetInteractAction().Invoke(interactor);
//                 target.GetInteractEvent().Invoke();
//             }
//         }
//
//         public static void InteractWithTarget(this IEntity interactor)
//         {
//             if (interactor.TryGetTargetInteractible(out IVariable<IEntity> target)) 
//                 interactor.InteractWith(target.Value);
//         }
//         
//         public static bool FindClosest(
//             Vector3 center,
//             float radius,
//             LayerMask layerMask,
//             out IEntity interactible
//         )
//         {
//             ArrayPool<Collider> arrayPool = ArrayPool<Collider>.Shared;
//             Collider[] colliders = arrayPool.Rent(32);
//
//             int count = Physics.OverlapSphereNonAlloc(center, radius, colliders, layerMask, QueryTriggerInteraction.Collide);
//
//             float minDistance = float.MaxValue;
//             interactible = null;
//
//             for (int i = 0; i < count; i++)
//             {
//                 Collider collider = colliders[i];
//                 Debug.Log($"FOUND {collider.name}", collider);
//                 if (!collider.TryGetEntity(out IEntity other) || !other.HasInteractibleTag())
//                     continue;
//
//                 Vector3 position = other.GetPosition().Value;
//                 float distance = Vector3.SqrMagnitude(position - center);
//                 if (distance >= minDistance)
//                     continue;
//
//                 interactible = other;
//                 minDistance = distance;
//             }
//
//             arrayPool.Return(colliders);
//             return interactible != null;
//         }
//     }
// }