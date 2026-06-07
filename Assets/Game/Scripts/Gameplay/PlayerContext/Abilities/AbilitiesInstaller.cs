using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class AbilitiesInstaller : IEntityInstaller<IPlayerContext>
    {
        [SerializeField]
        private AbilityEntityConfig[] _initialAbilities;
        
        public void Install(IPlayerContext playerContext)
        {
            EntityWorld<IAbilityEntity> abilities = new EntityWorld<IAbilityEntity>();
            foreach (AbilityEntityConfig config in _initialAbilities)
            {
                IAbilityEntity ability = config.Create(playerContext);
                abilities.Add(ability);
            }

            playerContext.AddValue(PlayerContextAPI.Abilities, abilities);
            abilities.BindTo(playerContext);
        }
    }
}