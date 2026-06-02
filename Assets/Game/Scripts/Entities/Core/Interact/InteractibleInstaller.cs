using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
    [Serializable]
    public sealed class InteractibleInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddInteractibleTag();
            entity.AddInteractCondition(new AndExpression<IEntity>());
            entity.AddInteractAction(new CompositeAction<IEntity>());
            entity.AddInteractEvent(new Event<IEntity>());
        }
    }
}