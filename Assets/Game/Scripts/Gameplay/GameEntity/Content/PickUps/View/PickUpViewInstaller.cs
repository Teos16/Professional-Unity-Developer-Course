using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PickUpViewInstaller : GameEntityInstaller
    {
        [SerializeField] private Optional<GameObject> _visual;
        [SerializeField] private Optional<ParticleSystem> _particleSystem;
        [SerializeField] private Optional<AudioSource> _audioSource;

        private readonly DisposableComposite _disposables = new();

        public override void Install(IGameEntity entity)
        {
            if (_visual)
                entity.GetValue(GameEntityAPI.InteractCommand)
                    .Subscribe(_ => _visual.Value.SetActive(false));
            if (_particleSystem)
                entity.GetValue(GameEntityAPI.InteractCommand)
                    .Subscribe(_ => _particleSystem.Value.Play()).AddTo(_disposables);
            if (_audioSource)
                entity.GetValue(GameEntityAPI.InteractCommand)
                    .Subscribe(_ => _audioSource.Value.Play()).AddTo(_disposables);
        }
    }
}