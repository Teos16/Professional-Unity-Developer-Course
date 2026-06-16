using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WeaponViewInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private Optional<ParticleSystem> _particleSystem;
        [SerializeField] private Optional<AudioSource> _audioSource;

        [SerializeField] private float _minSoundPitch = 0.9f;
        [SerializeField] private float _maxSoundPitch = 1.1f;
        
        private readonly DisposableComposite _disposables = new();

        public override void Install(IWeaponEntity weapon)
        {
            if (_particleSystem)
            {
                weapon.GetValue(WeaponEntityAPI.AttackCommand)
                    .Subscribe(_particleSystem.Value.Play)
                    .AddTo(_disposables);
            }
            
            if (_audioSource)
            {
                weapon.GetValue(WeaponEntityAPI.AttackCommand)
                    .Subscribe(() =>
                    {
                        _audioSource.Value.SetRandomPitch(_minSoundPitch, _maxSoundPitch);
                        _audioSource.Value.Play();
                    })
                    .AddTo(_disposables);
            }
        }
        
        public override void Uninstall(IWeaponEntity entity)
        {
            _disposables.Dispose();
        }
    }
}