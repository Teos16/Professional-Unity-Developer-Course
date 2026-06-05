using UnityEngine;

namespace Game.Gameplay
{
    public static partial class DamageUseCase
    {
        public static bool RaycastDamage(
            Vector3 position,
            Vector3 direction,
            float distance,
            LayerMask layerMask,
            int damage,
            TeamType attacker
        ) => Physics.Raycast(position, direction, out RaycastHit hit, distance, layerMask) &&
             TakeDamage(hit.collider, damage, attacker);

        public static bool TakeDamage(this Collider collider, int damage, TeamType attacker) =>
            collider.TryGetComponent(out IGameEntity target) && target.TakeDamage(damage, attacker);

        public static bool TakeDamage(this IGameEntity target, int damage, TeamType attacker)
        {
            if (!target.HasDamageableTag())
                return false;

            TeamType victim = target.GetTeam().Value;
            if (attacker == victim)
                return false;

            target.GetTakeDamageAction().Invoke(damage);
            target.GetTakeDamageEvent().Invoke(damage);

            return true;
        }
    }
}