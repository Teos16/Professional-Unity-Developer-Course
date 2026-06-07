using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(
        fileName = "MoveSpeedEffect",
        menuName = "Game/Effects/New MoveSpeedEffect"
    )]
    public sealed class MoveSpeedEffectConfig : EffectConfig
    {
        [field: SerializeField]
        public Const<float> Multiplier { get; private set; } = 2;

        public override bool CanApply(IGameEntity target) => 
            target.HasCharacterTag() && target.HasMoveSpeedMultiplier();

        protected override Effect Create(IGameEntity target) => 
            new MoveSpeedEffect(this, target);
    }
}