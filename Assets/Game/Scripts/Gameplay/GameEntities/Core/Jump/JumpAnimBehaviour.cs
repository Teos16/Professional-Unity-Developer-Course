using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class JumpAnimBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private static readonly int Jump = Animator.StringToHash(nameof(Jump));
        
        private Animator _animator;
        private ISignal _jumpEvent;
        
        public void Init(IGameEntity entity)
        {
            _animator = entity.GetAnimator();
            _jumpEvent = entity.GetJumpCommand();
            _jumpEvent.OnEvent += this.OnJump;
        }

        public void Dispose(IGameEntity entity)
        {
            _jumpEvent.OnEvent -= this.OnJump;
        }

        private void OnJump()
        {
            _animator.SetTrigger(Jump);
        }
    }
}