using System;
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
            entity.GetFireCondition().Add(entity.DoesHealthExist);
            entity.GetFireCondition().Add(entity.IsNotMoving);
            entity.GetFireCondition().Add(entity.CanFireWithWeapon);
            entity.GetFireCondition().Add(() => entity.GetCurrentTransport().Value == null);
            
            entity.GetFireAction().Add(entity.FireWithWeapon);
        }
    }
}