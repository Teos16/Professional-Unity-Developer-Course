using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CombatUseCase
    {
        public static void RayDamage(Vector3 position, Vector3 direction, float distance, LayerMask layerMask, int damage)
        {
            if (!Physics.Raycast(position, direction, out RaycastHit hit, distance, layerMask))
                return;

            if (hit.collider.TryGetComponent(out IEntity entity) && entity.HasDamageableTag()) 
                entity.GetTakeDamageAction().Invoke(damage);
        }
    }
}