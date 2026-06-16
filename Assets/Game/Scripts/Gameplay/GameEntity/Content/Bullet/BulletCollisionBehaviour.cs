using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BulletCollisionBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private readonly IGameContext _gameContext;
    
        private CollisionEvents _collisionEvents;
        private IValue<int> _damage;
        private IValue<TeamType> _team;
        private IAction _destroyAction;
    
        public BulletCollisionBehaviour(IGameContext gameContext) => _gameContext = gameContext;

        public void Init(IGameEntity entity)
        {
            _damage = entity.GetValue(GameEntityAPI.Damage);
            
            _team = entity.GetValue(GameEntityAPI.Team);
            _destroyAction = entity.GetValue(GameEntityAPI.DestroyAction);
            _collisionEvents = entity.GetValue(GameEntityAPI.CollisionEvents);
            _collisionEvents.OnEntered += OnCollisionEnter;
        }
    
        public void Dispose(IGameEntity entity) => _collisionEvents.OnEntered -= OnCollisionEnter;

        private void OnCollisionEnter(Collision collision)
        {
            Collider collider = collision.collider;
            
            if (!collider.TryGetComponent(out IGameEntity target)) 
                return;
            
            if (!_gameContext.TakeDamage(target, _damage.Value, _team.Value)) 
                return;
            
            _destroyAction.Invoke();
        }
    }
}