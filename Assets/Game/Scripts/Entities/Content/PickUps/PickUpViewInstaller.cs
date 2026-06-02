using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class PickUpViewInstaller : SceneEntityInstaller
    {
        [SerializeField] private Optional<ParticleSystem> _particleSystem;
        [SerializeField] private Optional<AudioSource> _audioSource;

        private readonly DisposableComposite _disposableComposite = new();

        public override void Install(IEntity entity)
        {
            if (_particleSystem) 
                entity.GetInteractEvent().Subscribe(_ => _particleSystem.Value.Play()).AddTo(_disposableComposite);

            if (_audioSource) 
                entity.GetInteractEvent().Subscribe(_ => _audioSource.Value.Play()).AddTo(_disposableComposite);
        }
    }
}