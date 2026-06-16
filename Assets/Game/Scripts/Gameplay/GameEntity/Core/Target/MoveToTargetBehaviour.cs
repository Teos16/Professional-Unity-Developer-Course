using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MoveToTargetBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IValue<IGameEntity> _target;
        private IVariable<Vector3> _aimDirection;
        private IVariable<Vector3> _moveDirection;
        private IRequest<Vector3> _moveRequest;
        
        public void Init(IGameEntity entity)
        {
            _target = entity.GetValue(GameEntityAPI.Target);
            _aimDirection = entity.GetValue(GameEntityAPI.AimDirection);
            _moveDirection = entity.GetValue(GameEntityAPI.MoveDirection);
            _moveRequest = entity.GetValue(GameEntityAPI.MoveRequest);
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            Vector3 entityPosition = entity.GetValue(GameEntityAPI.Position).Value;

            _moveDirection.Value = _target.Value == null || !_target.Value.IsAlive()
                ? Vector3.zero
                : _target.Value.GetValue(GameEntityAPI.Position).Value - entityPosition;
            _moveRequest.Invoke(_moveDirection.Value);
            
            if(_target.Value == null || !_target.Value.IsAlive())
                return;
            _aimDirection.Value = _moveDirection.Value;
        }
    }
}