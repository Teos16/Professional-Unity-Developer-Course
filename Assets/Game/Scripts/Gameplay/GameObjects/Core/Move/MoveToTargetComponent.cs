using Game;
using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(MoveComponent), typeof(PointComponent), typeof(TargetComponent))]
    public sealed class MoveToTargetComponent : MonoBehaviour
    {
        public interface ICondition
        {
            bool IsMet();
        }

        [SerializeField]
        private float _minDistance = 0.5f;

        private MoveComponent _moveComponent;
        private PointComponent _pointComponent;
        private TargetComponent _targetComponent;
        private ICondition _condition;
    
        private void Awake()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _pointComponent = GetComponent<PointComponent>();
            _targetComponent = GetComponent<TargetComponent>();
        }
    
        private void FixedUpdate()
        {
            if (_condition == null || !_condition.IsMet()) 
                return;
        
            if (_targetComponent.Target == null & _pointComponent.Point == null)
                return;

            Move();
        }

        public void SetCondition(ICondition condition) => _condition = condition;

        private void Move()
        {
            Vector3 destination;
            if (_targetComponent.Target != null)
                destination = _targetComponent.Target.transform.position;
            else if (_pointComponent.Point.HasValue)
                destination = _pointComponent.Point.Value;
            else
                return;

            Vector3 offset = destination - transform.position;

            if (offset.magnitude <= _minDistance)
            {
                _targetComponent.Target = null;
                _pointComponent.Point = null;
                return;
            }

            Vector3 direction = offset.normalized;
            _moveComponent.MoveStep(direction, Time.fixedDeltaTime);
        }
    }
}