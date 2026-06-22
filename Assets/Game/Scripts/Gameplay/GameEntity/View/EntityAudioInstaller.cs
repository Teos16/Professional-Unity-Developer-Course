using System;
using Atomic.Elements;
using Atomic.Entities;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class EntityAudioInstaller : IGameEntityInstaller
    {
        private const string BODY_FALL_EVENT = "body_fall_event";
        
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _onDamageTakenClips;
        [SerializeField] private AudioClip[] _deathClips;
        [SerializeField] private AudioClip[] _bodyFallClips;
        [SerializeField] private Optional<AudioClip[]> _moveClips;
        
        private readonly DisposableComposite _disposables = new();

        public void Install(IGameEntity entity)
        {
            entity.GetValue(GameEntityAPI.TakeDamageCommand)
                .Subscribe(_ => _audioSource.PlayOneShot(_onDamageTakenClips.GetRandom()))
                .AddTo(_disposables);

            entity.GetValue(GameEntityAPI.DeathEvent)
                .Subscribe(PlayDeathSounds)
                .AddTo(_disposables);

            entity.GetValue(GameEntityAPI.AnimationEvents).Value.Subscribe(BODY_FALL_EVENT, PlayBodyFallSound);
            if(_moveClips)
                entity.AddBehaviour(new EntityMoveSoundBehaviour(_audioSource, _moveClips.Value));
        }

        public void Uninstall(IGameEntity entity)
        {
            _disposables.Dispose();
            
            entity.GetValue(GameEntityAPI.AnimationEvents).Value.Unsubscribe(BODY_FALL_EVENT, PlayBodyFallSound);
        }

        private void PlayDeathSounds()
        {
            _audioSource.PlayOneShot(_deathClips.GetRandom());
        }
        
        private void PlayBodyFallSound()
        {
            _audioSource.PlayOneShot(_bodyFallClips.GetRandom());
        }
    }
}