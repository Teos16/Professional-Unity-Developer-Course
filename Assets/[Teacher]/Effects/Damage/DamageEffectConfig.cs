// using Atomic.Elements;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     [CreateAssetMenu(
//         fileName = "DamageEffect",
//         menuName = "Game/Effects/New DamageEffect"
//     )]
//     public sealed class DamageEffectConfig : EffectConfig
//     {
//         [field: SerializeField]
//         public Const<float> Damage { get; private set; }
//
//         public override bool CanApply(IGameEntity target) => target.HasDamageMultiplier();
//
//         protected override Effect Create(IGameEntity target)
//         {
//             return new DamageEntityEffect(this, target);
//         }
//     }
// }