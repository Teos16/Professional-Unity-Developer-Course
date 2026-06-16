using System;
using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class AttackInstaller : IGameEntityInstaller
    {
        public void Install(IGameEntity entity)
        {
            entity.AddValue(GameEntityAPI.AttackRequest, new Request());
            entity.AddValue(GameEntityAPI.AttackCommand, new Command());
            entity.AddBehaviour<AttackBehaviour>();
        }
    }
}