// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public sealed class CharacterInitializer : IPlayerContextInit
//     {
//         private readonly IGameContext _gameContext;
//         
//         public CharacterInitializer(IGameContext gameContext)
//         {
//             _gameContext = gameContext;
//         }
//         
//         public void Init(IPlayerContext playerContext)
//         {
//             IGameEntity character = playerContext.GetCharacter();
//             character.GetTeam().Value = playerContext.GetTeam().Value;
//             character.GetTransform().parent = _gameContext.GetWorldTransform(); 
//
//             Transform spawnPoint = _gameContext.NextPoint();
//             character.GetPosition().Value = spawnPoint.position;
//             character.GetRotation().Value = spawnPoint.rotation;
//         }
//     }
// }