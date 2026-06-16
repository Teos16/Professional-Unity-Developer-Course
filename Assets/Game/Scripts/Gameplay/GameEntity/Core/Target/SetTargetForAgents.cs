using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class SetTargetForAgentsBehaviour : IGameEntityInit, IEntityDispose
    {
        private IVariable<IGameEntity[]> _zombies;
        private TriggerEvents _triggerEvents;
        
        public void Init(IGameEntity entity)
        {
            _zombies = entity.GetValue(GameEntityAPI.Agents);
            _triggerEvents = entity.GetValue(GameEntityAPI.TriggerEvents);
            
            _triggerEvents.OnEntered += OnTriggerEnter;
            _triggerEvents.OnExited += OnTriggerExit;
        }
        
        public void Dispose(IEntity entity)
        {
            _triggerEvents.OnEntered -= OnTriggerEnter;
            _triggerEvents.OnExited -= OnTriggerExit;
        }
        
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IGameEntity target))
                if (target.IsPlayer())
                {
                    foreach (var zombie in _zombies.Value) 
                        zombie.GetValue(GameEntityAPI.Target).Value = target;
                }
        }
        
        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent(out IGameEntity target))
                if (target.IsPlayer())
                {
                    foreach (var zombie in _zombies.Value) 
                        zombie.GetValue(GameEntityAPI.Target).Value = null;
                }
        }
    }
}