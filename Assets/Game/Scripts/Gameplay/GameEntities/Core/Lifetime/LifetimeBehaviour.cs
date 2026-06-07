using Atomic.Elements;

namespace Game.Gameplay
{
    public sealed class LifetimeBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private ICooldown _cooldown;
        private IAction _destroy;
        
        public void Init(IGameEntity entity)
        {
            _cooldown = entity.GetLifetime();
            _destroy = entity.GetDestroyAction();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            _cooldown.Tick(deltaTime);
            if (_cooldown.IsCompleted()) 
                _destroy.Invoke();
        }
    }
}