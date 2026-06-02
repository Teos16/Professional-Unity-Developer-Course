using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class LifetimeInstaller : IEntityInstaller
    {
        [SerializeField]
        private Cooldown _cooldown = 5;
        
        public void Install(IEntity entity)
        {
            entity.AddLifetime(_cooldown);
            entity.AddBehaviour<LifetimeBehaviour>();
        }
    }
}