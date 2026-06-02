using System;
using System.Buffers;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public static class TargetUseCase
    {
        public static bool FindClosest(
            Vector3 center,
            float radius,
            LayerMask layerMask,
            out IEntity result,
            Predicate<IEntity> predicate
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
                if (!collider.TryGetEntity(out IEntity other) || !predicate.Invoke(other))
                    continue;

                Vector3 position = other.GetPosition().Value;
                float distance = Vector3.SqrMagnitude(position - center);
                if (distance >= minDistance)
                    continue;

                result = other;
                minDistance = distance;
            }

            arrayPool.Return(colliders);
            return result != null;
        }
    }
}