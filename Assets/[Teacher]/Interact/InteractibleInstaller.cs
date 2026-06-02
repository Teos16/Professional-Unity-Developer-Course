// using System;
// using Atomic.Elements;
// using Atomic.Entities;
//
// namespace SampleGame
// {
//     [Serializable]
//     public sealed class InteractibleInstaller : IEntityInstaller
//     {
//         public void Install(IEntity entity)
//         {
//             entity.AddInteractibleTag();
//             entity.AddInteractCondition(new AndExpression<IEntity>());
//             entity.AddInteractAction(new CompositeAction<IEntity>());
//             entity.AddTargetInteractible(new Variable<IEntity>());
//             entity.AddInteractEvent(new Event());
//         }
//     }
// }