using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class MoveSpeedAspect : IGameEntityAspect
    {
        [SerializeField] private Const<float> _speedMultiplier = 2.0f;
        
        public void Apply(IGameEntity entity)
        {
            if (entity.TryGetMoveSpeedMultiplier(out IExpression<float> multiplier))
                multiplier.Add(nameof(MoveSpeedAspect), _speedMultiplier);
        }

        public void Discard(IGameEntity entity)
        {
            if (entity.TryGetMoveSpeedMultiplier(out IExpression<float> multiplier))
                multiplier.Remove(nameof(MoveSpeedAspect));
        }
    }
}