using UnityEngine;

namespace Game.Gameplay
{
    public abstract class AbilityEntityConfig : ScriptableObject
    {
        public IAbilityEntity Create(IPlayerContext context)
        {
            AbilityEntity ability = new AbilityEntity(this.name);
            this.Install(ability, context);
            return ability;
        }

        protected abstract void Install(IAbilityEntity entity, IPlayerContext playerContext);
    }
}