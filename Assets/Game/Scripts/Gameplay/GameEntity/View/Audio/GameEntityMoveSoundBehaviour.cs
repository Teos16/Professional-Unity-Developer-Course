using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class GameEntityMoveSoundBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private AudioSource _audioSource;
        private AudioClip[] _moveClips;
        
        private AudioClip _lastClip;
        
        public GameEntityMoveSoundBehaviour(AudioSource audioSource, AudioClip[] moveClips)
        {
            _audioSource = audioSource;
            _moveClips = moveClips;
        }

        public void Init(IGameEntity entity) => 
            entity.GetValue(GameEntityAPI.AnimatorEventReceiver).Value.OnMoveStepEvent += PlayMoveAudioSound;

        public void Dispose(IGameEntity entity) => 
            entity.GetValue(GameEntityAPI.AnimatorEventReceiver).Value.OnMoveStepEvent -= PlayMoveAudioSound;

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