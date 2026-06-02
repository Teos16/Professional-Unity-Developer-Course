using System;
using Atomic.Elements;
using Atomic.Entities;
using Game;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class InteractorInstaller : IEntityInstaller
    {
        [SerializeField]
        private Transform _center;

        [SerializeField]
        private float _radius = 1;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private Cooldown _period = 0.2f;
        
        public void Install(IEntity entity)
        {
            entity.AddBehaviour(new DetectInteractibleBehaviour(_center, _radius, _layerMask, _period));
            entity.AddTargetInteractible(new Variable<IEntity>());
        }
    }
}