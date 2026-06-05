using System;
using Atomic.Elements;
using UnityEngine;
using Event = Atomic.Elements.Event;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class HealthInstaller : IGameEntityInstaller
    {
        [SerializeField]
        private Const<int> _health;
        
        public void Install(IGameEntity entity)
        {
            entity.AddHealth(new ReactiveVariable<int>(_health));
            entity.AddMaxHealth(_health);
            entity.AddDeathEvent(new Event());
        }
    }
}