// using System;
// using UnityEngine;
// using Zenject;
//
// namespace Game
// {
//     [Serializable]
//     public sealed class BulletSystemInstaller : Installer
//     {
//         [SerializeField]
//         private BulletPool _bulletPool;
//         
//         public override void InstallBindings()
//         {
//             this.Container.Bind<BulletPool>().FromInstance(_bulletPool).AsSingle();
//         }
//     }
// }