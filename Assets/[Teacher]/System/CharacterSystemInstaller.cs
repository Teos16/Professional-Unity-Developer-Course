// using System;
// using Atomic.Entities;
// using UnityEngine;
// using Zenject;
//
// namespace Game
// {
//     [Serializable]
//     public sealed class CharacterSystemInstaller : Installer
//     {
//         [SerializeField]
//         private SceneEntity _character;
//         
//         public override void InstallBindings()
//         {
//             this.Container
//                 .Bind<CharacterProvider>()
//                 .FromNew()
//                 .AsSingle()
//                 .WithArguments(_character);
//             
//             this.Container
//                 .BindInterfacesTo<CharacterMoveController>()
//                 .AsCached();
//             
//             this.Container
//                 .BindInterfacesTo<CharacterFireController>()
//                 .AsCached();
//             
//             this.Container
//                 .BindInterfacesTo<CharacterDropController>()
//                 .AsCached();
//             
//             this.Container
//                 .BindInterfacesTo<CharacterInteractController>()
//                 .AsCached();
//
//         }
//     }
// }