using System.Collections.Generic;
using Atomic.Entities;

namespace Game.Gameplay
{
    public static class LeaderboardUseCase
    {
        public static TeamType GetWinnerTeam(this IGameContext gameContext)
        {
            IDictionary<TeamType, IPlayerContext> players = gameContext.GetPlayers();
            int redMoney = players[TeamType.RED].GetValue(PlayerContextAPI.Score).Value;
            int blueMoney = players[TeamType.BLUE].GetValue(PlayerContextAPI.Score).Value;
            return redMoney > blueMoney
                ? TeamType.RED
                : blueMoney > redMoney
                    ? TeamType.BLUE
                    : TeamType.NEUTRAL;
        }
    }
}