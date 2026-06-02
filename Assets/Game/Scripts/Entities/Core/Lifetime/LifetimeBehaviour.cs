using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
    public sealed class LifetimeBehaviour : IEntityInit, IEntityFixedTick
    {
        private ICooldown _cooldown;
        private IAction _destroy;
        
        public void Init(IEntity entity)
        {
            _cooldown = entity.GetLifetime();
            _destroy = entity.GetDestroyAction();
        }

        public void FixedTick(IEntity entity, float deltaTime)
        {
            _cooldown.Tick(deltaTime);
            if (_cooldown.IsCompleted()) 
                _destroy.Invoke();
        }
    }
}