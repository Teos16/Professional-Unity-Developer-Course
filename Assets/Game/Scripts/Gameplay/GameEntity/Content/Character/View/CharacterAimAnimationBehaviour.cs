using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterAimAnimationBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private readonly int _isAimingHash = Animator.StringToHash("IsAiming");
        
        private IValue<Animator> _animator;
        private IVariable<bool> _isAiming;
        
        public void Init(IGameEntity entity)
        {
            _animator = entity.GetValue(GameEntityAPI.Animator);
            _isAiming = entity.GetValue(GameEntityAPI.IsAiming);
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            _animator.Value.SetBool(_isAimingHash, _isAiming.Value);
        }
    }
}