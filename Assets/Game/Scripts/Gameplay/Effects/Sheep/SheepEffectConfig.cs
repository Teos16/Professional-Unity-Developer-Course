using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(
        fileName = "SheepEffect",
        menuName = "Game/Effects/New SheepEffect"
    )]
    public sealed class SheepEffectConfig : EffectConfig
    {
        [field: SerializeField]
        public Const<float> SpeedMultiplier { get; private set; } = 0.5f;

        public override bool CanApply(IGameEntity target)
        {
            return target.HasCharacterTag();
        }

        protected override Effect Create(IGameEntity target)
        {
            return new SheepEffect(target, this);
        }
    }
}