using System;
using UnityEngine;

namespace Game
{
    public sealed class MoveRequestComponent : MonoBehaviour  
    {  
        public bool IsMoving => Time.time <= _moveTime;  
        
        public interface IAction  
        {  
            void Invoke(Vector2 direction);  
        }  
    
        public interface ICondition  
        {  
            bool Evaluate();  
        }

        [SerializeField] private Vector2 _moveDirection;
        [SerializeField] private float _moveDuration = 0.1f;
        [SerializeField] private bool _moveRequired;

        private IAction _moveAction;
        private ICondition _moveCondition;
        
        private float _moveTime;

        private void FixedUpdate()  
        {        
            if (_moveRequired && _moveDirection != Vector2.zero 
                              && (_moveCondition != null && _moveCondition.Evaluate()))  
            {            
                _moveAction.Invoke(_moveDirection);  
            }  
            _moveRequired = false;  
        }

        public void SetAction(IAction action) => _moveAction = action;

        public void SetCondition(ICondition condition) => _moveCondition = condition;

        public void Move(Vector2 direction)  
        {        
            _moveDirection = direction;  
            _moveTime = Time.time + _moveDuration; 
            _moveRequired = true;  
        }
    }
}