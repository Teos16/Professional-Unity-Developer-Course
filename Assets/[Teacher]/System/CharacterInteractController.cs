// using UnityEngine;
// using Zenject;
//
// namespace Game
// {
//     public sealed class CharacterInteractController : ITickable
//     {
//         private readonly CharacterProvider _characterProvider;
//
//         public CharacterInteractController(CharacterProvider characterProvider)
//         {
//             _characterProvider = characterProvider;
//         }
//
//         public void Tick()
//         {
//             if (Input.GetKeyDown(KeyCode.E)) 
//                 _characterProvider.Character.InteractWithTarget();
//         }
//     }
// }