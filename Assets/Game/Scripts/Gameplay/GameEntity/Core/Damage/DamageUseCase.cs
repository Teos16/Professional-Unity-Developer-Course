using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public static partial class DamageUseCase
    {
        public static bool TakeDamage(this IGameEntity target, int damage, TeamType attacker)
        {
            if(!target.TryGetValue(GameEntityAPI.Team, out IVariable<TeamType> victim))
                return false;
            
            if (attacker == victim.Value)
                return false;

            target.GetValue(GameEntityAPI.TakeDamageCommand).Invoke(damage);
            return true;
        }
    }
}