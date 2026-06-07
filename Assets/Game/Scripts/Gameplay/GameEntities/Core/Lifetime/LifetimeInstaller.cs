using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class LifetimeInstaller : IGameEntityInstaller
    {
        [SerializeField]
        private Cooldown _cooldown = 5;
        
        public void Install(IGameEntity entity)
        {
            entity.AddLifetime(_cooldown);
            entity.AddBehaviour<LifetimeBehaviour>();
        }
    }
}