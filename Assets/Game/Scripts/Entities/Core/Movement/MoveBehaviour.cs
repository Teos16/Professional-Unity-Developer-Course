using Atomic.Elements;
using Atomic.Entities;
using SampleGame;

namespace Game
{
    public sealed class MoveBehaviour : IEntityInit, IEntityFixedTick
    {
        private IFunction<bool> _moveCondition;
    
        public void Init(IEntity entity)
        {
           _moveCondition = entity.GetMoveConditon();
        }
    
        public void FixedTick(IEntity entity, float deltaTime)
        {
            if (entity.HasMoveableTag() && _moveCondition.Invoke()) 
                entity.MoveStep(deltaTime);
        }
    }
}