using System;
using Atomic.Elements;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class TakeDamageInstaller : IGameEntityInstaller
    {
        public void Install(IGameEntity entity)
        {
            entity.AddDamageableTag();
            entity.AddTakeDamageAction(new CompositeAction<int>());
            entity.AddTakeDamageEvent(new Event<int>());
        }
    }
}