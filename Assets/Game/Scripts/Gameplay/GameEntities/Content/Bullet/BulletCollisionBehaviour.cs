using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BulletCollisionBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private readonly IGameContext _gameContext;
        
        private TriggerEvents _trigger;
        private IValue<int> _damage;
        private IValue<TeamType> _team;
        private IAction _destroyAction;

        public BulletCollisionBehaviour(IGameContext gameContext) => 
            _gameContext = gameContext;

        public void Init(IGameEntity entity)
        {
            _damage = entity.GetDamage();
            _team = entity.GetTeam();
            _destroyAction = entity.GetDestroyAction();
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += OnTriggerEnter;
        }

        public void Dispose(IGameEntity entity)
        {
            _trigger.OnEntered -= OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IGameEntity target) && _gameContext.TakeDamage(target, _damage.Value, _team.Value)) 
                _destroyAction.Invoke();
        }
    }
}