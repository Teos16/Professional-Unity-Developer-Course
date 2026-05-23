using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(MoveComponent), typeof(LookComponent), typeof(TargetComponent))]
    public sealed class FollowTargetComponent : MonoBehaviour
    {
        public interface ICondition
        {
            bool Evaluate();
        }

        private MoveComponent _moveComponent;
        private LookComponent _lookComponent;
        private TargetComponent _targetComponent;
        private ICondition _condition;
        
        private void Awake()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _targetComponent = GetComponent<TargetComponent>();
        }
        
        private void FixedUpdate()
        {
            if (_condition == null || !_condition.Evaluate()) 
                return;
            
            if (_targetComponent.Target == null)
                return;

            Follow();
        }

        public void SetCondition(ICondition condition) => _condition = condition;

        private void Follow()
        {
            Vector2 direction = ((Vector2)_targetComponent.Target.transform.position 
                                 - (Vector2)transform.position).normalized;
            _moveComponent.Move(direction, Time.fixedDeltaTime);
            _lookComponent.Look(_targetComponent.Target.transform);
        }
    }
}