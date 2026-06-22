using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class AttackUseCase
    {
        public static void AttackTarget(this IGameEntity entity, 
            IGameContext gameContext, 
            int damage, 
            TeamType teamType)
        {
            IGameEntity target = entity.GetValue(GameEntityAPI.Target).Value;
            gameContext.TakeDamage(target, damage, teamType);
        }

        public static bool CanAttackCloseTarget(this IGameEntity entity, 
            float attackDistance, 
            LayerMask layerMask)
        {
            IGameEntity target = entity.GetValue(GameEntityAPI.Target).Value;
            TargetUseCase.FindClosest(entity.GetValue(GameEntityAPI.Transform).Value.position, 
                attackDistance, 
                layerMask, 
                out IGameEntity closestEntity, 
                entity.GetValue(GameEntityAPI.TargetDetectionType));
            return closestEntity == target;
        }
    }
}