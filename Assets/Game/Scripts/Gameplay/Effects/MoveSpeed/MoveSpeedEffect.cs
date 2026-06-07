using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MoveSpeedEffect : Effect
    {
        private readonly IValue<float> _multiplier;
        private readonly IGameEntity _target;

        public MoveSpeedEffect(MoveSpeedEffectConfig config, IGameEntity target) : base(config)
        {
            _multiplier = config.Multiplier;
            _target = target;
            _target.GetMoveSpeedMultiplier().Add(nameof(MoveSpeedEffect), _multiplier);
        }

        protected override void OnComplete()
        {
            bool remove = _target.GetMoveSpeedMultiplier().Remove(_multiplier);
            Debug.Log($"REMOVE SPEED MULTIPLER {remove}");
        }
    }
}