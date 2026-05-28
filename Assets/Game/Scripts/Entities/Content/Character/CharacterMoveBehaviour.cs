using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class CharacterMoveBehaviour : IEntityInit, IEntityFixedTick
    {
        private IVariable<Vector3> _moveDirection;
        private IVariable<Vector3> _rotationDirection;
        
        public void Init(IEntity entity)
        {
            _moveDirection = entity.GetMoveDirection();
            _rotationDirection = entity.GetRotationDirection();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            if(!entity.HasMoveableTag())
                return;
            
            Vector3 moveDirection = _moveDirection.Value;
            if(moveDirection == Vector3.zero)
                return;

            _rotationDirection.Value = moveDirection;
        }
    }
}