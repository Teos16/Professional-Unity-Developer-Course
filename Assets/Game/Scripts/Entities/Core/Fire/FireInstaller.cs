using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
    [Serializable]
    public sealed class FireInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddFireRequest(new Request());
            entity.AddFireCondition(new AndExpression());
            entity.AddFireAction(new CompositeAction());
            entity.AddFireEvent(new Event());
            entity.AddBehaviour<FireBehaviour>();
        }
    }
}