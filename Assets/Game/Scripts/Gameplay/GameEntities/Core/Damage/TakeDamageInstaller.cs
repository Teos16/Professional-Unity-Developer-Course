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
            entity.AddTakeDamageCommand(new Command<int>());
        }
    }
}