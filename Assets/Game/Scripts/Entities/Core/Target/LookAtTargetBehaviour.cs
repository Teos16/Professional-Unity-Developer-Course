using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class LookAtTargetBehaviour : IEntityInit, IEntityFixedTick
    {
        private IValue<IEntity> _target;
        private IValue<Vector3> _position;
        private IVariable<Vector3> _rotationDirection;
        
        public void Init(IEntity entity)
        {
            _target = entity.GetTarget();
            _position = entity.GetPosition();
            _rotationDirection = entity.GetRotationDirection();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            IEntity target = _target.Value;
            if(target == null)
                return;

            Vector3 targetPosition = target.GetPosition().Value;
            Vector3 delta = targetPosition - _position.Value;
            
            delta.y = 0;
            _rotationDirection.Value = delta.normalized;
        }
    }
}