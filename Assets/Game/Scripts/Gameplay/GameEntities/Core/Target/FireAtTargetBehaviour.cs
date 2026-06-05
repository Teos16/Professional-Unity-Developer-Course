using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class FireAtTargetBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IValue<IEntity> _target;
        private IRequest _fireRequest;

        public void Init(IGameEntity entity)
        {
            _target = entity.GetTarget();
            _fireRequest = entity.GetFireRequest();
        }
        
        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            IEntity target = _target.Value;
            if (target == null)
                return;
            
            _fireRequest.Invoke();
        }
    }
}