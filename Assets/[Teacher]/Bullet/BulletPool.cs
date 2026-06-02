// using Atomic.Entities;
// using Zenject;
//
// namespace Game
// {
//     public sealed class BulletPool : SceneEntityPool
//     {
//         [Inject]
//         private readonly DiContainer _container;
//
//         protected override void OnCreate(SceneEntity entity)
//         {
//             _container.InjectGameObject(entity.gameObject);
//             base.OnCreate(entity);
//         }
//     }
// }