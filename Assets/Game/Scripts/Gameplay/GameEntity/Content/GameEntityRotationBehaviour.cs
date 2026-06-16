using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class GameEntityRotationBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IGameEntity _self;
        
        private IValue<Vector3> _moveInput;
        private IValue<Vector3> _aimDirection;
        private IVariable<Quaternion> _rotation;
        private IRequest<Vector3> _rotateRequest;
        
        private IValue<Animator> _animator;
        
        public void Init(IGameEntity entity)
        {
            _self = entity;
            
            _moveInput = entity.GetValue(GameEntityAPI.MoveDirection);
            _aimDirection = entity.GetValue(GameEntityAPI.AimDirection);
            _rotation = entity.GetValue(GameEntityAPI.Rotation);
            _rotateRequest = entity.GetValue(GameEntityAPI.RotateRequest);
            
            _animator = entity.GetValue(GameEntityAPI.Animator);
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (entity.IsAiming())
                _rotateRequest.Invoke(_aimDirection.Value);
            else if (entity.IsMoving())
                _rotateRequest.Invoke(_moveInput.Value);
            
            if (!_self.IsAiming()) 
                _rotation.Value *= _animator.Value.deltaRotation;
        }
    }
}