using UnityEngine;

namespace Game
{
    public sealed class AttackTargetComponent : MonoBehaviour
    {
        public interface ICondition
        {
            bool Evaluate();
        }

        public interface IAction
        {
            void Invoke(GameObject target);
        }
        
        [SerializeField] private AttackConfig _config;
        
        private TargetComponent _targetComponent;
        private ICondition _condition;
        private IAction _action;
        
        private float _nextAllowedAttackTime;

        private void Awake() => _targetComponent = GetComponent<TargetComponent>();

        private void FixedUpdate()
        {
            if (_condition == null || !_condition.Evaluate()) 
                return;
            
            if (_targetComponent.Target == null)
                return;
            
            if (Time.time < _nextAllowedAttackTime) 
                return;
            
            Attack();
        }

        public void SetCondition(ICondition condition) => _condition = condition;
        
        public void SetAction(IAction action) => _action = action;
        
        public void Attack()
        {
            GameObject go = _targetComponent.Target;
            
            _action?.Invoke(go);

            _nextAllowedAttackTime = Time.time + _config.Cooldown;
        }
    }
}