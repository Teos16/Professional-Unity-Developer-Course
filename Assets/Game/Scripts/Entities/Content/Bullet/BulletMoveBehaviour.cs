using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class BulletMoveBehaviour : IEntityInit, IEntityFixedTick
    {
        private IValue<Quaternion> _rotation;
        private IVariable<Vector3> _moveDirection;
        
        public void Init(IEntity entity)
        {
            _rotation = entity.GetRotation();
            _moveDirection = entity.GetMoveDirection();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            if(!entity.HasMoveableTag())
                return;
            
            _moveDirection.Value = _rotation.Value * Vector3.forward;
        }
    }
}