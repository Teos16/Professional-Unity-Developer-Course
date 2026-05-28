using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class RotationBehaviour : IEntityInit, IEntityFixedTick
    {
        private IVariable<Quaternion> _rotation;
        private IValue<float> _rotationSpeed;
        private IVariable<Vector3> _rotationDirection;
    
        public void Init(IEntity entity)
        {
            _rotation = entity.GetRotation();
            _rotationSpeed = entity.GetRotationSpeed();
            _rotationDirection = entity.GetRotationDirection();
        }
    
        public void FixedTick(IEntity entity, float deltaTime)
        {
            if(_rotationDirection.Value == Vector3.zero)
                return;
            
            Quaternion currentRotation = _rotation.Value;
            Quaternion targetRotation = Quaternion.LookRotation(_rotationDirection.Value, Vector3.up);
            _rotation.Value = Quaternion.RotateTowards(
                currentRotation, targetRotation, _rotationSpeed.Value * deltaTime);
        }
    }
}