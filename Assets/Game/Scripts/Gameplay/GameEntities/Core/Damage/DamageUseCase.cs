using UnityEngine;

namespace Game.Gameplay
{
    public static partial class DamageUseCase
    {
        public static bool TakeDamage(this Collider collider, int damage, TeamType attacker) =>
            collider.TryGetComponent(out IGameEntity target) && target.TakeDamage(damage, attacker);
        
        public static bool TakeDamage(this IGameEntity target, int damage, TeamType attacker)
        {
            if (!target.HasDamageableTag())
                return false;

            TeamType victim = target.GetTeam().Value;
            if (attacker == victim)
                return false;

            target.GetTakeDamageCommand().Invoke(damage);
            return true;
        }
    }
}