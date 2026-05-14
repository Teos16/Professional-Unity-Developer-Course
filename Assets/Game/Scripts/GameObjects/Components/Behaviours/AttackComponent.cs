using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public sealed class AttackComponent : MonoBehaviour
    {
        /*
        public interface ICondition
        {
            bool EvaluateTarget(GameObject target);
            bool EvaluateOtherConditions();
        }
        */

        [SerializeField] private AttackConfig _config;
        [SerializeField, ShowIf("CanPush")] private PushRigidbodyComponent _pushRigidbodyComponent;
        
        private Func<GameObject, bool> _targetCondition;
        private Func<bool> _otherConditions;
        
        private float _nextAllowedAttackTime;

        //public void SetCondition(ICondition condition) => _condition = condition;
        
        public void SetConditions(Func<GameObject, bool> targetCondition, Func<bool> otherConditions)
        {
            _targetCondition = targetCondition;
            _otherConditions = otherConditions;
        }

        public void Attack(Collider2D col)
        {
            /*
            if(!_condition.EvaluateOtherConditions()) 
                return;
                */
            if (_otherConditions != null && !_otherConditions()) 
                return;
            
            if (Time.time < _nextAllowedAttackTime) 
                return;

            GameObject go = col.gameObject;
            if (_targetCondition != null && !_targetCondition(go)) 
                return;

            if (_config.CanDamage && go.TryGetComponent(out HealthComponent health) && health.IsAlive) 
                health.TakeDamage(_config.Damage);

            if (_config.CanPush && col.attachedRigidbody != null && _config.PushConfig != null) 
                _pushRigidbodyComponent.TryPush(col.attachedRigidbody, _config.PushConfig, transform.position);

            _nextAllowedAttackTime = Time.time + _config.Cooldown;
        }

        public void Attack(Collision2D col) => Attack(col.collider);

        private bool CanPush() => _config != null && _config.CanPush;
    }
}