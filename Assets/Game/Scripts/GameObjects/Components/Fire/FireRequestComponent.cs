using System;
using UnityEngine;

namespace SampleGame.Components
{
    public sealed class FireRequestComponent : MonoBehaviour
    {
        public event Action OnFire;
        
        private Func<bool> _condition;
        private Action _action;
        private bool _required;
        
        public void SetCondition(Func<bool> condition) => _condition = condition;
        public void SetAction(Action action) => _action = action;
        
        public void Fire() => _required = true;

        private void FixedUpdate()
        {
            if(_required && _condition != null && _condition.Invoke())
            {
                _action?.Invoke();
                this.OnFire?.Invoke();
            }
            
            _required = false;
        }
    }
}