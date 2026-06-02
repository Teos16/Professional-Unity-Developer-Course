using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class RotateInstaller : IEntityInstaller
    {
        public void Install(IEntity entity)
        {
            entity.AddRotateRequest(new Request<Vector3>());
            entity.AddRotateCondition(new AndExpression<Vector3>());
            entity.AddRotateAction(new CompositeAction<Vector3, float>());
            entity.AddRotateEvent(new Event<Vector3>());
            entity.AddBehaviour<RotateBehaviour>();
        }
    }
}