using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
    public sealed class FireBehaviour : IEntityInit, IEntityFixedTick
    {
        private IRequest _request;
        private IFunction<bool> _condition;
        private IAction _action;
        private IEvent _event;
        
        public void Init(IEntity entity)
        {
            _request = entity.GetFireRequest();
            _condition = entity.GetFireCondition();
            _action = entity.GetFireAction();
            _event = entity.GetFireEvent();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            if (_request.Consume() && _condition.Invoke())
            {
                _action.Invoke();
                _event.Invoke();
            }
        }
    }
}