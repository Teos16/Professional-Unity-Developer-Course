using System;
using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class MoveInstaller
    {
        [SerializeField] private Const<float> _moveSpeed;
        [SerializeField] private Variable<Vector3> _moveDirection;
        
        public void Install(IEntity entity)
        {
            entity.AddMoveableTag();
            
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddMoveDirection(_moveDirection);
            entity.AddMoveConditon(new AndExpression());
            
            entity.AddBehaviour<MoveBehaviour>();
        }
    }
}