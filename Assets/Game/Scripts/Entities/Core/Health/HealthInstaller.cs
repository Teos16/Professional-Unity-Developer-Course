using System;
using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class HealthInstaller : IEntityInstaller
    {
        [SerializeField] private ReactiveVariable<int> _health;
        
        public void Install(IEntity entity)
        {
            entity.AddDamageableTag();
            entity.AddHealth(_health);
        }
    }
}