using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class EntityVFXInstaller : IGameEntityInstaller
    {
        private const string BODY_FALL_EVENT = "body_fall_event";
        
        [SerializeField] private ParticleSystem _onDamageTakenVfx;
        [SerializeField] private ParticleSystem _onDeathVfx;

        private readonly DisposableComposite _disposables = new();

        public void Install(IGameEntity entity)
        {
            entity.GetValue(GameEntityAPI.TakeDamageCommand)
                .Subscribe(_ => _onDamageTakenVfx.Play())
                .AddTo(_disposables);
            
            entity.GetValue(GameEntityAPI.AnimationEvents).Value.Subscribe(BODY_FALL_EVENT, PlayBodyFallVfx);
        }

        public void Uninstall(IGameEntity entity)
        {
            _disposables.Dispose();
            
            entity.GetValue(GameEntityAPI.AnimationEvents).Value.Unsubscribe(BODY_FALL_EVENT, PlayBodyFallVfx);
        }

        private void PlayBodyFallVfx() => _onDeathVfx.Play();
    }
}