using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public sealed class FollowComponent : MonoBehaviour
    {
        public interface ICondition
        {
            bool EvaluateTarget(GameObject target);
            bool EvaluateOtherConditions();
        }
        
        [SerializeField, ReadOnly] private GameObject _target;
        [SerializeField] private TriggerComponent _triggerComponent;

        private MoveRequestComponent _moveRequestComponent;
        private LookComponent _lookComponent;
        private ICondition _condition;
        
        private void Awake()
        {
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _lookComponent = GetComponent<LookComponent>();
        }
        
        private void OnEnable() => _triggerComponent.OnTargetsChanged += OnTargetsChanged;

        private void OnDisable() => _triggerComponent.OnTargetsChanged -= OnTargetsChanged;

        private void FixedUpdate()
        {
            if(!_condition.EvaluateOtherConditions())
                return;
            
            if (_target == null)
                return;

            if (!_target.TryGetComponent(out HealthComponent health) || !health.IsAlive)
            {
                _target = null;
                return;
            }

            Vector2 direction = ((Vector2)_target.transform.position - (Vector2)transform.position).normalized;
            _moveRequestComponent.Move(direction);
            _lookComponent.Look(_target.transform);
        }
        
        public void SetCondition(ICondition condition) => _condition = condition;

        private void OnTargetsChanged(IReadOnlyCollection<Collider2D> targets)
        {
            
            if (_target != null)
            {
                foreach (Collider2D col in targets)
                {
                    if (col.gameObject == _target)
                        return;
                }
            }

            _target = null;
            foreach (Collider2D col in targets)
            {
                if (_condition.EvaluateTarget(col.gameObject))
                {
                    _target = col.gameObject;
                    break;
                }
            }
        }
    }
}