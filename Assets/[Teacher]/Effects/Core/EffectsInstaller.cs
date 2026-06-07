// using System;
// using System.Collections.Generic;
// using Atomic.Elements;
// using Atomic.Entities;
//
// namespace Game.Gameplay
// {
//     [Serializable]
//     public sealed class EffectsInstaller : IGameEntityInstaller
//     {
//         public void Install(IGameEntity entity)
//         {
//             entity.AddEffects(new ReactiveList<Effect>());
//             entity.AddBehaviour<UpdateEffectsBehaviour>();
//         }
//     }
// }