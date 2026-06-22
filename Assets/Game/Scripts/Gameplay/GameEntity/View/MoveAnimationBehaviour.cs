using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MoveAnimationBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private readonly int _isMovingHash = Animator.StringToHash("IsMoving");
        
        private IValue<Animator> _animator;
        
        public void Init(IGameEntity entity) => _animator = entity.GetValue(GameEntityAPI.Animator);

        public void FixedTick(IGameEntity entity, float deltaTime) => 
            _animator.Value.SetBool(_isMovingHash, entity.IsMoving());
    }
}