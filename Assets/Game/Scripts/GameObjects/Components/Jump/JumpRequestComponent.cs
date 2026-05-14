using System;
using UnityEngine;

namespace Game
{
    public sealed class JumpRequestComponent : MonoBehaviour 
    {
        public event Action OnJumped;
        
        public interface ICondition  
        {  
            bool Evaluate();  
        }
        
        public interface IAction
        {
            void Invoke();  
        }
        
        [SerializeField] private float _jumpLag = 0.05f;

        private ICondition _jumpCondition;
        private IAction _jumpAction;
        
        private float _jumpTimer = -1f;
        
        private void FixedUpdate()
        {
            if (_jumpTimer < 0) return;

            _jumpTimer -= Time.fixedDeltaTime;

            if (_jumpTimer <= 0)
                Jump();
        }

        public void SetAction(IAction action) => _jumpAction = action;

        public void SetCondition(ICondition condition) => _jumpCondition = condition;

        public bool TryJump()  
        {
            if (_jumpCondition != null && _jumpCondition.Evaluate())
            {
                _jumpTimer = _jumpLag;
                return true;
            }
            return false; 
        }

        private void Jump()
        {
            _jumpAction?.Invoke();
            _jumpTimer = -1f;
            OnJumped?.Invoke();
        }
    }
}