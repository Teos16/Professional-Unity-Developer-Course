using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class HealthInstaller
    {
        [SerializeField]
        private ReactiveVariable<int> _health;
        
        public void Install(IEntity entity)
        {
            entity.AddDamageableTag();
            entity.AddHealth(_health);
        }
    }
}