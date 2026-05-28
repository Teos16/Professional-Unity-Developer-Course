using System;
using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class TransformInstaller : IEntityInstaller
    {
        [SerializeField] private Transform _transform;
        
        public void Install(IEntity entity)
        {
            entity.AddPosition(new TransformPositionVariable(_transform));
            entity.AddRotation(new TransformRotationVariable(_transform));
        }
    }
}