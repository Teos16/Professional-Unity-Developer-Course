using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WeaponViewInstaller : WeaponEntityInstaller
    {
        [SerializeField]
        private Optional<ParticleSystem> _particleSystem;

        [SerializeField]
        private Optional<AudioSource> _audioSource;

        private readonly DisposableComposite _disposableComposite = new();

        public override void Install(IWeaponEntity entity)
        {
            if (_particleSystem) 
                entity.GetFireEvent().Subscribe(_particleSystem.Value.Play).AddTo(_disposableComposite);

            if (_audioSource) 
                entity.GetFireEvent().Subscribe(_audioSource.Value.Play).AddTo(_disposableComposite);
        }
        
        public override void Uninstall(IWeaponEntity entity)
        {
            _disposableComposite.Dispose();
        }
    }
}