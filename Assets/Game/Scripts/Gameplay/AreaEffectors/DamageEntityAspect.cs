using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class DamageEntityAspect : IGameEntityAspect
    {
        [SerializeField]
        private Const<float> _damageMultiplier = 2;
        
        public void Apply(IGameEntity entity)
        {
            if (entity.TryGetDamageMultiplier(out IExpression<float> damage))
            {
                damage.Add(nameof(DamageEntityAspect), _damageMultiplier);
            }
        }

        public void Discard(IGameEntity entity)
        {
            if (entity.TryGetDamageMultiplier(out IExpression<float> damage))
            {
                damage.Remove(nameof(DamageEntityAspect));
            }
        }
    }
}