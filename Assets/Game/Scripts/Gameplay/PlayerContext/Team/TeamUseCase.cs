using Atomic.Entities;

namespace Game.Gameplay
{
    public static partial class TeamUseCase
    {
        public static bool IsEnemy(this IPlayerContext context, IGameEntity target) => 
            context.GetValue(PlayerContextAPI.Team).Value != target.GetTeam().Value;
    }
}