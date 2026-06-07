using Game.Gameplay;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "StunEffect",
        menuName = "Game/Effects/New StunEffect"
    )]
    public sealed class StunEffectConfig : EffectConfig
    {
        public override bool CanApply(IGameEntity target) => 
            target.HasCharacterTag() && target.HasIsStunned();

        protected override Effect Create(IGameEntity target) => 
            new StunEffect(this, target);
    }
}