using Atomic.Elements;

namespace Game.Gameplay
{
    public sealed class JumpRequestBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest _request;
        private ICommand _command;
        
        public void Init(IGameEntity entity)
        {
            _request = entity.GetJumpRequest();
            _command = entity.GetJumpCommand();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_request.Consume()) 
                _command.Invoke();
        }
    }
}