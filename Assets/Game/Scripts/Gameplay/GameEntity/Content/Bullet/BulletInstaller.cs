using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BulletInstaller : GameEntityInstaller
    {
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private LifetimeInstaller _lifetimeInstaller;
        [SerializeField] private CollisionEvents _collisionEvents;
        [SerializeField] private Const<int> _damage = 1;
        [SerializeField] private Const<float> _moveSpeed = 45;
        [SerializeField] private Variable<TeamType> _team = TeamType.Player;
    
        public override void Install(IGameEntity entity)
        {
            GameContext gameContext = GameContext.Instance;
    
            _transformInstaller.Install(entity);
            _lifetimeInstaller.Install(entity);
            entity.AddValue(GameEntityAPI.Team, _team);
            entity.AddValue(GameEntityAPI.CollisionEvents, _collisionEvents);
            entity.AddValue(GameEntityAPI.Damage, _damage);
            
            entity.WhenFixedTick(dt => entity.MoveStepWithTransform(
                entity.GetValue(GameEntityAPI.Transform).Value.forward, _moveSpeed, dt));

            entity.AddValue(GameEntityAPI.DestroyAction, new InlineAction(() => gameContext.DespawnBullet(entity)));
            entity.AddValue(GameEntityAPI.RespawnCommand, new Command());
            entity.GetValue(GameEntityAPI.RespawnCommand)
                .AddAction(entity.GetValue(GameEntityAPI.Lifetime).ResetTime);
            
            entity.AddBehaviour(new BulletCollisionBehaviour(gameContext));
        }
    }
}