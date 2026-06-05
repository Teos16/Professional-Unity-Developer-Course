using UnityEngine;

namespace Game.Gameplay
{
    public static partial class DamageUseCase
    {
        public static bool RaycastDamage(
            this IGameContext gameContext,
            Vector3 position,
            Vector3 direction,
            float distance,
            LayerMask layerMask,
            int damage,
            TeamType attacker
        )
        {
            return Physics.Raycast(position, direction, out RaycastHit hit, distance, layerMask)
            && hit.collider.TryGetComponent(out IGameEntity target)
            && gameContext.TakeDamage(target, damage, attacker);
        }

        public static bool TakeDamage(this IGameContext gameContext, IGameEntity target, int damage, TeamType attacker)
        {
            if (!target.TakeDamage(damage, attacker))
                return false;
            
            if(target.IsDead())
                gameContext.ProcessKill(new KillArgs()
                {
                    victim = target.GetTeam().Value,
                    killer = attacker
                });
                
            return true;
        }
    }
}