using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class InteractBehaviour : IGameEntityInit, IGameEntityTick
    {
        private const float INTERACT_COOLDOWN = 0.2f;
        
        private IGameEntity _self;
        private ICooldown _cooldown;

        public void Init(IGameEntity entity)
        {
            _self = entity;
            _cooldown = new Cooldown(INTERACT_COOLDOWN, 0);
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            _cooldown.Tick(deltaTime);
            
            if (!_cooldown.IsCompleted())
                return;
            
            IVariable<IGameEntity> target = entity.GetValue(GameEntityAPI.Target);

            if (target.Value == null)
                return;

            if (target.Value == _self)
                return;

            _self.InteractWith(target.Value);
                
            _cooldown.ResetTime();
        }
    }
}