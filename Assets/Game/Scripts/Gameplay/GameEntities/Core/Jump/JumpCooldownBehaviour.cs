using Atomic.Elements;

namespace Game.Gameplay
{
    public sealed class JumpCooldownBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private ICooldown _cooldown;
        
        public void Init(IGameEntity entity)
        {
            _cooldown = entity.GetJumpCooldown();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            _cooldown.Tick(deltaTime);
        }
    }
}