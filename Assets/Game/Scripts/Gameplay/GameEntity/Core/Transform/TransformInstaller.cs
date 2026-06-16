using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class TransformInstaller : IGameEntityInstaller
    {
        [SerializeField] private Transform _transform;

        public void Install(IGameEntity entity)
        {
            entity.AddValue(GameEntityAPI.Transform, new Variable<Transform>(_transform));
            entity.AddValue(GameEntityAPI.Position, new TransformPositionVariable(_transform));
            entity.AddValue(GameEntityAPI.Rotation, new TransformRotationVariable(_transform));
        }
    }
}