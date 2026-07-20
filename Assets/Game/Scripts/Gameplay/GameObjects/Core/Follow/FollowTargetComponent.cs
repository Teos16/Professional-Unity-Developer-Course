using Game;
using SampleGame;
using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(MoveComponent), typeof(TargetComponent))]
    public sealed class FollowTargetComponent : MonoBehaviour
    {
        public interface ICondition
        {
            bool IsMet();
        }

        private MoveComponent _moveComponent;
        private TargetComponent _targetComponent;
        private ICondition _condition;
        
        private void Awake()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _targetComponent = GetComponent<TargetComponent>();
        }
        
        private void FixedUpdate()
        {
            if (_condition == null || !_condition.IsMet()) 
                return;
            
            if (_targetComponent.Target == null)
                return;

            Follow();
        }

        public void SetCondition(ICondition condition) => _condition = condition;

        private void Follow()
        {
            Vector3 direction = (_targetComponent.Target.transform.position 
                                 - transform.position).normalized;
            _moveComponent.MoveStep(direction, Time.fixedDeltaTime);
        }
    }
}