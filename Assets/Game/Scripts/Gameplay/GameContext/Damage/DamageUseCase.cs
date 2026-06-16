namespace Game.Gameplay
{
    public static partial class DamageUseCase
    {
        public static bool TakeDamage(this IGameContext gameContext, IGameEntity target, int damage, TeamType attacker)
        {
            if (!target.TakeDamage(damage, attacker)) 
                return false;

            if (target.IsDead())
                gameContext.ProcessKill(attacker);
                
            return true;
        }
    }
}