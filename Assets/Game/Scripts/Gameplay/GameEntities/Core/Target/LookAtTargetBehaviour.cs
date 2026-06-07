using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class LookAtTargetBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IValue<IGameEntity> _target;
        private IValue<Vector3> _position;
        private IRequest<Vector3> _rotateRequest;

        public void Init(IGameEntity entity)
        {
            _target = entity.GetTarget();
            _position = entity.GetPosition();
            _rotateRequest = entity.GetRotateRequest();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            IGameEntity target = _target.Value;
            if (target == null)
                return;

            Vector3 targetPosition = target.GetPosition().Value;
            Vector3 delta = targetPosition - _position.Value;
            delta.y = 0;
            
            _rotateRequest.Invoke(delta.normalized);
        }
    }
}