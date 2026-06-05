using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class InteractorInstaller : IGameEntityInstaller
    {
        [SerializeField]
        private Transform _center;

        [SerializeField]
        private float _radius = 1;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private Cooldown _period = 0.2f;
        
        public void Install(IGameEntity entity)
        {
            entity.AddBehaviour(new DetectInteractibleBehaviour(_center, _radius, _layerMask, _period));
            entity.AddTargetInteractible(new Variable<IGameEntity>());
        }
    }
}