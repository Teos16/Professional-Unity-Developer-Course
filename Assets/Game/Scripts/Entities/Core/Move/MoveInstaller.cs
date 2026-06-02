using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class MoveInstaller
    {
        [SerializeField] private Const<float> _moveDuration = 0.05f;
        
        public void Install(IEntity entity)
        {
            entity.AddMoveableTag();
            entity.AddMoveRequest(new Request<Vector3>());
            entity.AddMoveCondition(new AndExpression<Vector3>());
            entity.AddMoveAction(new CompositeAction<Vector3, float>());
            entity.AddMoveEvent(new Event<Vector3>());
            entity.AddMoveDuration(_moveDuration);
            entity.AddMoveTime(new Variable<float>(-_moveDuration));
            entity.AddBehaviour(new MoveBehaviour());
        }
    }
}