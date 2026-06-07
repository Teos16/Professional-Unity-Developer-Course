using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class GravityInstaller : IGameEntityInstaller
    {
        public void Install(IGameEntity entity)
        {
            entity.AddVerticalSpeed(new Variable<float>());
            entity.AddBehaviour<GravityBehaviour>();
        }
    }
}