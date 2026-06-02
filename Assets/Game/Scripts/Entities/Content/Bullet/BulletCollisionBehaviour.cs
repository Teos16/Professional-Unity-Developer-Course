using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class BulletCollisionBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEvents _trigger;
        private IValue<int> _damage;
        private IAction _destroyAction;

        public void Init(IEntity entity)
        {
            _destroyAction = entity.GetDestroyAction();
            _damage = entity.GetDamage();
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += OnTriggerEnter;
        }

        public void Dispose(IEntity entity)
        {
            _trigger.OnEntered -= OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IEntity entity) && entity.HasDamageableTag())
            {
                entity.GetTakeDamageAction().Invoke(_damage.Value);
                _destroyAction.Invoke();
            }
        }
    }
}