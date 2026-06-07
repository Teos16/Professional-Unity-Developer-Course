using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WeaponViewInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField]
        private Optional<ParticleSystem> _particleSystem;

        [SerializeField]
        private Optional<AudioSource> _audioSource;

        private readonly DisposableComposite _disposableComposite = new();

        public override void Install(IWeaponEntity entity)
        {
            if (_particleSystem) 
                entity.GetFireCommand().Subscribe(_particleSystem.Value.Play).AddTo(_disposableComposite);

            if (_audioSource) 
                entity.GetFireCommand().Subscribe(_audioSource.Value.Play).AddTo(_disposableComposite);
        }
        
        public override void Uninstall(IWeaponEntity entity)
        {
            _disposableComposite.Dispose();
        }
    }
}