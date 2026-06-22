using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class EntityMoveSoundBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private const string MOVE_STEP_EVENT = "move_step_event";
        
        private AudioSource _audioSource;
        private AudioClip[] _moveClips;
        
        private AudioClip _lastClip;
        
        public EntityMoveSoundBehaviour(AudioSource audioSource, AudioClip[] moveClips)
        {
            _audioSource = audioSource;
            _moveClips = moveClips;
        }

        public void Init(IGameEntity entity) => 
            entity.GetValue(GameEntityAPI.AnimationEvents).Value.Subscribe(MOVE_STEP_EVENT, PlayMoveAudioSound);

        public void Dispose(IGameEntity entity) =>
            entity.GetValue(GameEntityAPI.AnimationEvents).Value.Unsubscribe(MOVE_STEP_EVENT, PlayMoveAudioSound);

        private void PlayMoveAudioSound()
        {
            if(_moveClips == null || _moveClips.Length == 0)
                return;

            AudioClip clip = _moveClips.GetRandomExcept(_lastClip);
            _lastClip = clip;
            _audioSource.PlayOneShot(clip);
        }
    }
}