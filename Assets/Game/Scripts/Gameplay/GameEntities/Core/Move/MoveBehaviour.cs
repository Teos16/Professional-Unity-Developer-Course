using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MoveBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest<Vector3> _moveRequest;
        private ICommand<MoveArgs> _moveCommand;

        public void Init(IGameEntity entity)
        {
            _moveRequest = entity.GetMoveRequest();
            _moveCommand = entity.GetMoveCommand();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_moveRequest.Consume(out Vector3 direction) && direction != Vector3.zero) 
                _moveCommand.Invoke(new MoveArgs(direction, deltaTime));
        }
    }
}