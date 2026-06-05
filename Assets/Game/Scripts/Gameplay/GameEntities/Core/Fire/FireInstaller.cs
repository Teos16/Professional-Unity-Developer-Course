using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class FireInstaller : IGameEntityInstaller
    {
        public void Install(IGameEntity entity)
        {
            entity.AddFireRequest(new Request());
            entity.AddFireCondition(new AndExpression());
            entity.AddFireAction(new CompositeAction());
            entity.AddFireEvent(new Event());
            entity.AddBehaviour<FireBehaviour>();
        }
    }
}