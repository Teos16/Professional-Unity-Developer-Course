using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class ArmorEntityAspect : IGameEntityAspect
    {
        [SerializeField] private Const<float> _armorPercent = 0.2f;
        
        public void Apply(IGameEntity entity)
        {
            if (entity.TryGetArmorMultiplier(out IExpression<float> armorPercent)) 
                armorPercent.Add(nameof(ArmorEntityAspect), _armorPercent);
        }

        public void Discard(IGameEntity entity)
        {
            if (entity.TryGetArmorMultiplier(out IExpression<float> armorPercent)) 
                armorPercent.Remove(nameof(MoveSpeedAspect));
        }
    }
}