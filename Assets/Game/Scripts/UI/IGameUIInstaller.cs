using Atomic.Entities;
using Game.Gameplay;

namespace Game.UI
{
    namespace Game.Gameplay
    {
        /// <summary>
        /// Interface for installing and configuring an <see cref="IGameUI"/> instance.
        /// </summary>
        public interface IGameUIInstaller : IEntityInstaller<IGameUI>
        {
        }
    }
}
