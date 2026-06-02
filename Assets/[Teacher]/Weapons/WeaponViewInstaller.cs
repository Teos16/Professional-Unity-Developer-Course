// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class WeaponViewInstaller : SceneEntityInstaller
//     {
//         [SerializeField]
//         private Optional<ParticleSystem> _particleSystem;
//
//         [SerializeField]
//         private Optional<AudioSource> _audioSource;
//
//         private readonly DisposableComposite _disposableComposite = new();
//
//         public override void Install(IEntity entity)
//         {
//             if (_particleSystem) 
//                 entity.GetFireEvent().Subscribe(_particleSystem.Value.Play).AddTo(_disposableComposite);
//
//             if (_audioSource) 
//                 entity.GetFireEvent().Subscribe(_audioSource.Value.Play).AddTo(_disposableComposite);
//         }
//     }
// }