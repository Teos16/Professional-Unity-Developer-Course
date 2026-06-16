using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class GameEntityVFXInstaller : IGameEntityInstaller
    {
        [SerializeField] private ParticleSystem _onDamageTakenVfx;
        [SerializeField] private ParticleSystem _onDeathVfx;

        private readonly DisposableComposite _disposables = new();

        public void Install(IGameEntity entity)
        {
            entity.GetValue(GameEntityAPI.TakeDamageCommand)
                .Subscribe(_ => _onDamageTakenVfx.Play())
                .AddTo(_disposables);
            
            entity.GetValue(GameEntityAPI.AnimatorEventReceiver).Value.OnBodyFallEvent += PlayBodyFallVfx;
        }

        public void Uninstall(IGameEntity entity)
        {
            _disposables.Dispose();
            
            entity.GetValue(GameEntityAPI.AnimatorEventReceiver).Value.OnBodyFallEvent -= PlayBodyFallVfx;
        }

        private void PlayBodyFallVfx() => _onDeathVfx.Play();
    }
}