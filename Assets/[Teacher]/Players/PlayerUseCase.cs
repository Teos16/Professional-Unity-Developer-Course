// using System.Collections.Generic;
//
// namespace Game.Gameplay
// {
//     public static class PlayerUseCase
//     {
//         public static IPlayerContext GetPlayer(this IGameContext context, IGameEntity character)
//         {
//             TeamType teamType = character.GetTeam().Value;
//             return GetPlayer(context, teamType);
//         }
//
//         public static IPlayerContext GetPlayer(this IGameContext context, TeamType teamType)
//         {
//             IDictionary<TeamType, IPlayerContext> players = context.GetPlayers();
//             return players[teamType];
//         }
//     }
// }