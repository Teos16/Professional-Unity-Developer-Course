// using System;
// using System.Collections.Generic;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     [Serializable]
//     public sealed class PlayersInstaller : IGameContextInstaller
//     {
//         public void Install(IGameContext gameContext)
//         {
//             Dictionary<TeamType, IPlayerContext> playerMap = new Dictionary<TeamType, IPlayerContext>();
//             gameContext.AddPlayers(playerMap);
//             PlayerContext[] playerContexts = GameObject.FindObjectsByType<PlayerContext>(
//                 FindObjectsSortMode.InstanceID
//             );
//             foreach (PlayerContext playerContext in playerContexts)
//             {
//                 playerContext.WhenInstall(() => playerMap.Add(playerContext.GetTeam().Value, playerContext));
//                 gameContext.WhenDisable(playerContext.Disable);
//             }
//         }
//     }
// }