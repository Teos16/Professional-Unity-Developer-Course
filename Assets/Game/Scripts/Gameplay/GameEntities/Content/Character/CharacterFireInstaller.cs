using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class CharacterFireInstaller : IGameEntityInstaller
    {
        [SerializeField]
        private FireInstaller _fireInstaller;

        public void Install(IGameEntity entity)
        {
            _fireInstaller.Install(entity);
            
            entity.GetFireCommand()
                .AddCondition(entity.IsHealthExists)
                .AddCondition(entity.IsNotMoving)
                .AddCondition(entity.CanFireWithWeapon)
                .AddCondition(() => entity.GetCurrentTransport().Value == null)
                .AddCondition(() => !entity.GetIsStunned().Value)
                .AddAction(entity.FireWithWeapon);
        }
    }
}