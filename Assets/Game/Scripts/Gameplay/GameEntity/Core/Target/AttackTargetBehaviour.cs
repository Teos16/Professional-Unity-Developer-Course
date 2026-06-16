using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class AttackTargetBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IValue<IGameEntity> _target;
        private IRequest _attackRequest;

        public void Init(IGameEntity entity)
        {
            _target = entity.GetValue(GameEntityAPI.Target);
            _attackRequest = entity.GetValue(GameEntityAPI.AttackRequest);
        }
        
        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            IGameEntity target = _target.Value;
            if (target == null)
                return;
            
            _attackRequest.Invoke();
        }
    }
}