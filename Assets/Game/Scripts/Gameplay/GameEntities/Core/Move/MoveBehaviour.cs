using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MoveBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest<Vector3> _moveRequest;
        private IFunction<Vector3, bool> _moveCondition;
        private IAction<Vector3, float> _moveAction;
        private IVariable<float> _moveTime;
        private IEvent<Vector3> _moveEvent;

        public void Init(IGameEntity entity)
        {
            _moveRequest = entity.GetMoveRequest();
            _moveCondition = entity.GetMoveCondition();
            _moveAction = entity.GetMoveAction();
            _moveEvent = entity.GetMoveEvent();
            _moveTime = entity.GetMoveTime();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_moveRequest.Consume(out Vector3 moveDirection) && moveDirection != Vector3.zero &&
                _moveCondition.Invoke(moveDirection))
            {
                _moveAction.Invoke(moveDirection, deltaTime);
                _moveTime.Value = Time.time;
                _moveEvent.Invoke(moveDirection);
            }
        }
    }
}