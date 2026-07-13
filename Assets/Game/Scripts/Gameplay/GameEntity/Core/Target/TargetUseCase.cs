using System.Buffers;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class TargetUseCase
    {
        public static bool TryFindClosest(
            Vector3 center,
            float radius,
            LayerMask layerMask,
            out IGameEntity result,
            IPredicate<IGameEntity> predicate)
        {
            Collider[] colliders = RentColliders(out int count, center, radius, layerMask);
            bool found = TryFindClosestInColliders(center, colliders, count, predicate, out result);
            ReturnColliders(colliders);
            return found;
        }

        public static bool TryFindClosestInColliders(
            Vector3 center,
            Collider[] colliders,
            int count,
            IPredicate<IGameEntity> predicate,
            out IGameEntity result)
        {
            float minDistance = float.MaxValue;
            result = null;
            for (int i = 0; i < count; i++)
            {
                Collider collider = colliders[i];
                if (collider.TryGetComponent(out IGameEntity other) && predicate.Invoke(other))
                {
                    Vector3 pos = other.GetValue(GameEntityAPI.Transform).Value.position;
                    float dist = Vector3.SqrMagnitude(pos - center);
                    if (dist < minDistance)
                    {
                        minDistance = dist;
                        result = other;
                    }
                }
            }
            return result != null;
        }

        public static bool HavePlayerTarget(this IGameEntity entity)
        {
            return entity.TryGetValue(GameEntityAPI.Target, out IVariable<IGameEntity> target) 
                   && target.Value != null 
                   && target.Value.HasTag(GameEntityAPI.PlayerTag)
                   && target.Value.IsAlive();
        }
        
        public static bool IsPlayer(this IGameEntity entity) => entity != null 
                                                                      && entity.HasTag(GameEntityAPI.PlayerTag);
        
        public static bool IsTargetClose(this IGameEntity entity, float distance) => 
            entity.TryGetValue(GameEntityAPI.Target, out IVariable<IGameEntity> target) 
            && target.Value != null 
            && entity.LessOrEqualsDistance(target.Value, distance);
        
        private static Collider[] RentColliders(out int count, Vector3 center, float radius, LayerMask layerMask)
        {
            Collider[] colliders = ArrayPool<Collider>.Shared.Rent(32);
            count = Physics.OverlapSphereNonAlloc(center, radius, colliders, layerMask, QueryTriggerInteraction.Collide);
            return colliders;
        }

        private static void ReturnColliders(Collider[] colliders) => ArrayPool<Collider>.Shared.Return(colliders);
    }
}