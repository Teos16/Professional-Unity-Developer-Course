using System;
using System.Buffers;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class TargetUseCase
    {
        public static bool FindClosest(
            Vector3 center,
            float radius,
            LayerMask layerMask,
            out IGameEntity result,
            IPredicate<IGameEntity> predicate
        )
        {
            ArrayPool<Collider> arrayPool = ArrayPool<Collider>.Shared;
            Collider[] colliders = arrayPool.Rent(32);

            int count = Physics.OverlapSphereNonAlloc(center, radius, colliders, layerMask, 
                QueryTriggerInteraction.Collide);

            float minDistance = float.MaxValue;
            result = null;

            for (int i = 0; i < count; i++)
            {
                Collider collider = colliders[i];
                
                if (!collider.TryGetComponent(out IGameEntity other) || !predicate.Invoke(other))
                    continue;

                Vector3 position = other.GetValue(GameEntityAPI.Transform).Value.position;
                float distance = Vector3.SqrMagnitude(position - center);
                if (distance >= minDistance)
                    continue;
                
                result = other;
                minDistance = distance;
                
            }
            
            arrayPool.Return(colliders);
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
    }
}