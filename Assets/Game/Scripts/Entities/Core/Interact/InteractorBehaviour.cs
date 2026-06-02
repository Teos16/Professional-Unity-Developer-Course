using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class InteractorBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEvents _triggerEvents;
        private IEntity _self;

        public void Init(IEntity entity)
        {
            _self = entity;
            _triggerEvents = entity.GetTrigger();
            _triggerEvents.OnEntered += OnTriggerEntered;
        }

        public void Dispose(IEntity entity)
        {
            _triggerEvents.OnEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out IEntity target))
                _self.InteractWith(target);
        }
    }
}