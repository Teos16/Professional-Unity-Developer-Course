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
            entity.AddFireCommand(new Command());
            entity.AddBehaviour<FireBehaviour>();
        }
    }
}