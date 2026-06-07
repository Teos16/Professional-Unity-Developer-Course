using System;
using Atomic.Elements;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class InteractibleInstaller : IGameEntityInstaller
    {
        public void Install(IGameEntity entity)
        {
            entity.AddInteractibleTag();
            entity.AddInteractCommand(new Command<IGameEntity>());
        }
    }
}