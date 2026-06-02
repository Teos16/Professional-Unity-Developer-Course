using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class LookAtTargetBehaviour : IEntityInit, IEntityFixedTick
    {
        private IValue<IEntity> _target;
        private IValue<Vector3> _position;
        private IRequest<Vector3> _rotateRequest;
        
        public void Init(IEntity entity)
        {
            _target = entity.GetTarget();
            _rotateRequest = entity.GetRotateRequest();
            _position = entity.GetPosition();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            IEntity target = _target.Value;
            if (target == null)
                return;

            Vector3 targetPosition = target.GetPosition().Value;
            Vector3 delta = targetPosition - _position.Value;
            delta.y = 0;
            
            _rotateRequest.Invoke(delta.normalized);
        }
    }
}