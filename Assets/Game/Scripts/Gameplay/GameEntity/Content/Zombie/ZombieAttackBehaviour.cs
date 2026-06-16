using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class ZombieAttackBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private AnimatorEventReceiver _animationEvents;
        private IGameEntity _self;

        public void Init(IGameEntity entity)
        {
            _self = entity;
            _animationEvents = entity.GetValue(GameEntityAPI.AnimatorEventReceiver).Value;

            _animationEvents.OnFireEvent += Attack;
        }

        public void Dispose(IGameEntity entity) => _animationEvents.OnFireEvent -= Attack;

        private void Attack() => _self.AttackWithWeapon();
    }
}