using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterAimAnimationBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private readonly int _isAimingHash = Animator.StringToHash("IsAiming");
        private readonly int _aimXHash = Animator.StringToHash("AimX");
        private readonly int _aimZHash = Animator.StringToHash("AimZ");
        
        private IValue<Animator> _animator;
        private IValue<Transform> _transform;

        private IVariable<Vector3> _moveDirection;
        private IVariable<Vector3> _aimDirection;
        
        public void Init(IGameEntity entity)
        {
            _animator = entity.GetValue(GameEntityAPI.Animator);
            _transform = entity.GetValue(GameEntityAPI.Transform);

            _moveDirection = entity.GetValue(GameEntityAPI.MoveDirection);
            _aimDirection = entity.GetValue(GameEntityAPI.AimDirection);
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            _animator.Value.SetBool(_isAimingHash, entity.IsAiming());
            
            if (!entity.IsAiming()) return;
        
            Vector3 aimVector = entity.IsMoving() 
                ? _transform.Value.InverseTransformDirection(_moveDirection.Value)
                : _aimDirection.Value;
        
            _animator.Value.SetFloat(_aimXHash, aimVector.x);
            _animator.Value.SetFloat(_aimZHash, aimVector.z);
        }
    }
}