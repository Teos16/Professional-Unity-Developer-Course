using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class InteractorInstaller : IGameEntityInstaller
    {
        [SerializeField] private Transform _center;
        [SerializeField] private float _radius = 1;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Cooldown _period = 0.2f;
        
        public void Install(IGameEntity entity)
        {
            entity.AddValue(GameEntityAPI.Target, new Variable<IGameEntity>());
            entity.AddBehaviour(new DetectBehaviour(_center, _radius, _layerMask, _period));
        }
    }
}