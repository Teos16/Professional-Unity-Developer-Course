using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public static class KillUseCase
    {
        public static void ProcessKill(this IGameContext gameContext, TeamType killer)
        {
            if(killer != TeamType.Player)
                return;
            
            IReactiveVariable<int> score = gameContext.GetValue(GameContextAPI.Score);
            score.Value++;
        }
    }
}