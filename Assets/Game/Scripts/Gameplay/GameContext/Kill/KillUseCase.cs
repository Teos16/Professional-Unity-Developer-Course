using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public struct KillArgs
    {
        public TeamType killer;
        public TeamType victim;
    }
    
    public static class KillUseCase
    {
        public static void ProcessKill(this IGameContext context, KillArgs args)
        {
            if(args.killer == args.victim)
                return;

            IDictionary<TeamType, IPlayerContext> players = context.GetPlayers();
            IPlayerContext killer = players[args.killer];
            IReactiveVariable<int> score = killer.GetValue(PlayerContextAPI.Score);
            score.Value++;
        }
    }
}