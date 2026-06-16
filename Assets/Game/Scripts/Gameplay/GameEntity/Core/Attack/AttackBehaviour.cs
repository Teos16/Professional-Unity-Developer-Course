using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class AttackBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IRequest _request;
        private ICommand _command;

        public void Init(IGameEntity entity)
        {
            _request = entity.GetValue(GameEntityAPI.AttackRequest);
            _command = entity.GetValue(GameEntityAPI.AttackCommand);
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            if (_request.Consume()) 
                _command.Invoke();
        }
    }
}