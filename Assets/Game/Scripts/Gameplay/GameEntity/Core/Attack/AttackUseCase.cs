using System.Buffers;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class AttackUseCase
    {
        public static bool AttackTarget(this IGameEntity entity,
            IGameContext gameContext,
            int damage,
            TeamType teamType,
            float attackDistance,
            LayerMask layerMask,
            IPredicate<IGameEntity> targetPredicate)
        {
            Transform center = entity.GetValue(GameEntityAPI.Transform).Value;

            ArrayPool<Collider> arrayPool = ArrayPool<Collider>.Shared;
            Collider[] colliders = arrayPool.Rent(32);

            int count = Physics.OverlapSphereNonAlloc(center.position, attackDistance, colliders, layerMask,
                QueryTriggerInteraction.Collide);

            if (!TargetUseCase.TryFindClosestInColliders(center.position, colliders, count,
                    targetPredicate, out IGameEntity target))
            {
                arrayPool.Return(colliders);
                return false;
            }

            arrayPool.Return(colliders);

            if (target == null | !entity.LessOrEqualsDistance(target, attackDistance))
                return false;

            gameContext.TakeDamage(target, damage, teamType);
            return true;
        }
    }
}