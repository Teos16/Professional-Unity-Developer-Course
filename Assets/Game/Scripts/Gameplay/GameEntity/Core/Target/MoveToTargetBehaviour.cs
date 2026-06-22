using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MoveToTargetBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IValue<IGameEntity> _target;
        private IRequest<Vector3> _moveRequest;
        
        public void Init(IGameEntity entity)
        {
            _target = entity.GetValue(GameEntityAPI.Target);
            _moveRequest = entity.GetValue(GameEntityAPI.MoveRequest);
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            Vector3 entityPosition = entity.GetValue(GameEntityAPI.Transform).Value.position;

            Vector3 moveDirection = _target.Value == null || !_target.Value.IsAlive()
                ? Vector3.zero
                : _target.Value.GetValue(GameEntityAPI.Transform).Value.position - entityPosition;
            _moveRequest.Invoke(moveDirection);
        }
    }
}