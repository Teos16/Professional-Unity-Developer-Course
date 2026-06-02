// using Atomic.Elements;
// using Atomic.Entities;
// using SampleGame;
//
// namespace Game
// {
//     public sealed class FireAtTargetBehaviour : IEntityInit, IEntityTick
//     {
//         private IValue<IEntity> _target;
//         private IRequest _fireRequest;
//         
//         public void Init(IEntity entity)
//         {
//             _target = entity.GetTarget();
//             _fireRequest = entity.GetFireRequest();
//         }
//
//         void IEntityTick.Tick(IEntity entity, float deltaTime)
//         {
//             IEntity target = _target.Value;
//             if (target == null)
//                 return;
//             
//             _fireRequest.Invoke();
//         }
//     }
// }