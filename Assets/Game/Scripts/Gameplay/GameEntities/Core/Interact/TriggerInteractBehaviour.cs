using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TriggerInteractBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private TriggerEvents _triggerEvents;
        private IGameEntity _self;

        public void Init(IGameEntity entity)
        {
            _self = entity;
            _triggerEvents = entity.GetTrigger();
            _triggerEvents.OnEntered += this.OnTriggerEntered;
        }

        public void Dispose(IGameEntity entity)
        {
            _triggerEvents.OnEntered -= this.OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out IGameEntity target))
                _self.InteractWith(target);
        }
    }
}