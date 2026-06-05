using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class MoveInstaller : IGameEntityInstaller
    {
        [SerializeField]
        private Const<float> _moveDuration;
        
        public void Install(IGameEntity entity)
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