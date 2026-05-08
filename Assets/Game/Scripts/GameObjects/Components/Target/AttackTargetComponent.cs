using System;
using SampleGame.Components;
using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(TargetComponent), typeof(FireRequestComponent))]
    public sealed class AttackTargetComponent : MonoBehaviour
    {
        public Func<bool> _condition;
        
        private TargetComponent _targetComponent;
        private FireRequestComponent _fireRequestComponent;
        
        public void SetCondition(Func<bool> condition) => _condition = condition;
        
        private void Awake()
        {
            _targetComponent = this.GetComponent<TargetComponent>();
            _fireRequestComponent = this.GetComponent<FireRequestComponent>();
        }
        
        private void Update()
        {
            if (_condition != null && _condition.Invoke())
                Attack();
        }

        private void Attack()
        {
            GameObject target = _targetComponent.Target;
            
            if(target == null || !target.TryGetComponent(out HealthComponent health) || !health.IsAlive())
                return;
            
            _fireRequestComponent.Fire();
        }
    }
}