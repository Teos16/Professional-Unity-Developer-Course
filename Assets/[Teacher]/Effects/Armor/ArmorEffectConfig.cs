// using Atomic.Elements;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     [CreateAssetMenu(
//         fileName = "ArmorEffect",
//         menuName = "Game/Effects/New ArmorEffect"
//     )]
//     public sealed class ArmorEffectConfig : EffectConfig
//     {
//         [field: SerializeField]
//         public Const<float> ArmorPercent { get; private set; } = 0.2f;
//
//         public override bool CanApply(IGameEntity target) => target.HasCharacterTag() && target.HasExtraArmor();
//
//         protected override Effect Create(IGameEntity target) => new ArmorEffect(this, target);
//     }
// }