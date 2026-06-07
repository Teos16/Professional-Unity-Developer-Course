using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(
        fileName = "PoisonEffect",
        menuName = "Game/Effects/New PoisonEffect"
    )]
    public sealed class PoisonEffectConfig : EffectConfig
    {
        [field: SerializeField]
        public Const<float> Period { get; private set; } = 1;

        [field: SerializeField]
        public Const<int> Damage { get; private set; }
        
        public override bool CanApply(IGameEntity target) => 
            target.HasCharacterTag() && target.HasTakeDamageCommand();

        protected override Effect Create(IGameEntity target) => 
            new PoisonEffect(target, this);
    }
}