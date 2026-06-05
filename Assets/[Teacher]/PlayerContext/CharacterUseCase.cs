// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public static class CharacterUseCase
//     {
//         public static void RespawnCharacter(this IPlayerContext playerContext, IGameContext gameContext)
//         {
//             IGameEntity character = playerContext.GetCharacter();
//             Transform nextPoint = gameContext.NextPoint();
//             character.GetPosition().Value = nextPoint.position;
//             character.GetRotation().Value = nextPoint.rotation;
//
//             character.GetRespawnAction().Invoke();
//             DebugRespawn(character);
//         }
//
//         private static void DebugRespawn(IGameEntity character)
//         {
//             TeamType teamType = character.GetTeam().Value;
//             Debug.Log($"<color={teamType.ToString().ToLower()}>Player {teamType} has respawned!</color>");
//         }
//     }
// }