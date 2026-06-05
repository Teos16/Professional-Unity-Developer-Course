using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game.App
{
    [Serializable]
    public sealed class MenuLoadInstaller : IEntityInstaller<IAppContext>
    {
        public void Install(IAppContext context)
        {
            context.AddMenuLoadedEvent(new Event());
            context.AddBehaviour<MenuLoadController>();
        }
    }
}