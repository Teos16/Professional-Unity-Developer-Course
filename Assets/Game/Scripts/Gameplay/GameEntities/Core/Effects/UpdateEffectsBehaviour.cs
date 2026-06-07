using System.Collections.Generic;

namespace Game.Gameplay
{
    public sealed class UpdateEffectsBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IList<Effect> _effects;
        
        public void Init(IGameEntity entity)
        {
            _effects = entity.GetEffects();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            for (int i = 0; i < _effects.Count; i++)
            {
                Effect effect = _effects[i];
                effect.Update(deltaTime);
                if (effect.IsCompleted) 
                    entity.DiscardEffect(effect);
            }
        }
    }
}