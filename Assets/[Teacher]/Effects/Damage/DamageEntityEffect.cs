// using Atomic.Elements;
//
// namespace Game.Gameplay
// {
//     public sealed class DamageEntityEffect : Effect
//     {
//         private readonly IValue<float> _multiplier;
//         private readonly IGameEntity _target;
//         
//         public DamageEntityEffect(DamageEffectConfig config, IGameEntity target) : base(config)
//         {
//             _multiplier = config.Damage;
//             _target = target;
//             _target.GetDamageMultiplier().Add(_multiplier);
//         }
//
//         protected override void OnComplete()
//         {
//             _target.GetDamageMultiplier().Remove(_multiplier);
//         }
//     }
// }