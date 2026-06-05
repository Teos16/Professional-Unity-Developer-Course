using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class InteractibleInstaller : IGameEntityInstaller
    {
        public void Install(IGameEntity entity)
        {
            entity.AddInteractibleTag();
            entity.AddInteractCondition(new AndExpression<IGameEntity>());
            entity.AddInteractAction(new CompositeAction<IGameEntity>());
            entity.AddInteractEvent(new Event<IGameEntity>());
        }
    }
}