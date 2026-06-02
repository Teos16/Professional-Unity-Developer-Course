// using UnityEngine;
// using Zenject;
//
// namespace Game
// {
//     public sealed class CharacterFireController : ITickable
//     {
//         private readonly CharacterProvider _characterProvider;
//
//         public CharacterFireController(CharacterProvider characterProvider)
//         {
//             _characterProvider = characterProvider;
//         }
//         
//         public void Tick()
//         {
//             if (Input.GetKeyDown(KeyCode.Space))
//                 _characterProvider.Character.GetFireRequest().Invoke();
//         }
//     }
// }