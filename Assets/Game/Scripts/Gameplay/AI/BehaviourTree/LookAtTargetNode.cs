using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class LookAtTargetNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;

        [SerializeField]
        [BlackboardValueKey(typeof(float))]
        private string _stoppingDistanceKey;

        [SerializeField]
        [BlackboardValueKey(typeof(GameObject))]
        private string _targetKey;

        [SerializeField]
        [BlackboardValueKey(typeof(float))]
        private string _minAngleKey;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) ||
                !_blackboard.TryGetValue(_targetKey, out GameObject target) || !target ||
                !_blackboard.TryGetValue(_stoppingDistanceKey, out float stoppingDistance))
                return BehaviourResult.Failure;

            Vector3 delta = target.transform.position - character.transform.position;
            delta.y = 0;

            if (delta.sqrMagnitude > stoppingDistance * stoppingDistance)
                return BehaviourResult.Failure;

            Vector3 direction = delta.normalized;
            float angle = Vector3.Angle(character.transform.forward, direction);
            float minAngle = _blackboard.GetValue<float>(_minAngleKey);
            if (angle <= minAngle)
                return BehaviourResult.Success;
            
            RotateTransformComponent rotateComponent = character.GetComponent<RotateTransformComponent>();
            rotateComponent.RotateTowards(direction, deltaTime);
            return BehaviourResult.Running;
        }
    }
}