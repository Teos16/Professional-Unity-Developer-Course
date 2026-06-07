using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class RotateBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest<Vector3> _request;
        private ICommand<RotateArgs> _command;

        public void Init(IGameEntity entity)
        {
            _request = entity.GetRotateRequest();
            _command = entity.GetRotateCommand();
        }
        
        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_request.Consume(out Vector3 direction) && direction != Vector3.zero) 
                _command.Invoke(new RotateArgs(direction, deltaTime));
        }
    }
}