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
        public static void ProcessKill(this IGameContext gameContext, KillArgs args)
        {
            if (args.victim == args.killer)
                return;

            // Add to player
            IDictionary<TeamType, IPlayerContext> players = gameContext.GetPlayers();
            IPlayerContext killerPlayer = players[args.killer];
            IReactiveVariable<int> score = killerPlayer.GetValue(PlayerContextAPI.Score);
            score.Value++;

            // Add to leaderboard
            IReactiveDictionary<TeamType, int> leaderboard = gameContext.GetLeaderboard();
            leaderboard.TryGetValue(args.killer, out int scoreValue);
            leaderboard[args.killer] = scoreValue + 1;
        }
    }
}