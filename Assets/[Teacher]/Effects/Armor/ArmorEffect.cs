// using Atomic.Elements;
//
// namespace Game.Gameplay
// {
//     public sealed class ArmorEffect : Effect
//     {
//         private readonly IValue<float> _multiplier;
//         private readonly IGameEntity _target;
//
//         public ArmorEffect(ArmorEffectConfig config, IGameEntity target) : base(config)
//         {
//             _multiplier = config.ArmorPercent;
//             _target = target;
//             _target.GetExtraArmor().Add(_multiplier);
//         }
//
//         protected override void OnComplete()
//         {
//             _target.GetExtraArmor().Remove(_multiplier);
//         }
//     }
// }