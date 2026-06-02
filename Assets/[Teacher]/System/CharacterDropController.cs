// using UnityEngine;
// using Zenject;
//
// namespace Game
// {
//     public sealed class CharacterDropController : ITickable
//     {
//         private readonly CharacterProvider _characterProvider;
//
//         public CharacterDropController(CharacterProvider characterProvider)
//         {
//             _characterProvider = characterProvider;
//         }
//
//         public void Tick()
//         {
//             if (Input.GetKeyDown(KeyCode.Q)) 
//                 _characterProvider.Character.GetDropAction().Invoke();
//         }
//     }
// }