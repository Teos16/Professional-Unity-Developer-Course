using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PickUpViewInstaller : GameEntityInstaller
    {
        [SerializeField] private VisualDisableOnInteractInstaller _visualDisableOnInteractInstaller;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private AudioSource _audioSource;

        private readonly DisposableComposite _disposables = new();

        public override void Install(IGameEntity entity)
        {
            entity.GetValue(GameEntityAPI.InteractCommand)
                .Subscribe(_ => _particleSystem.Play()).AddTo(_disposables);
            entity.GetValue(GameEntityAPI.InteractCommand)
                .Subscribe(_ => _audioSource.Play()).AddTo(_disposables);
            _visualDisableOnInteractInstaller.Install(entity);
        }
    }
}