using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class ZombieAttackBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private const string FIRE_EVENT = "fire_event";
        
        private AnimationEvents _animationEvents;
        private IGameEntity _self;

        public void Init(IGameEntity entity)
        {
            _self = entity;
            _animationEvents = entity.GetValue(GameEntityAPI.AnimationEvents).Value;

            _animationEvents.Subscribe(FIRE_EVENT, Attack);
        }

        public void Dispose(IGameEntity entity) => _animationEvents.Unsubscribe(FIRE_EVENT, Attack);

        private void Attack() => _self.AttackWithWeapon();
    }
}