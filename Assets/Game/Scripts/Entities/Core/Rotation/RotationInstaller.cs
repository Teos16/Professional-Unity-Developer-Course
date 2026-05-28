using System;
using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class RotationInstaller : IEntityInstaller
    {
        [SerializeField] private Const<float> _rotationSpeed;
        [SerializeField] private Variable<Vector3> _rotationDirection;
        
        public void Install(IEntity entity)
        {
            entity.AddRotationSpeed(_rotationSpeed);
            entity.AddRotationDirection(_rotationDirection);
            entity.AddBehaviour<RotationBehaviour>();
        }
    }
}