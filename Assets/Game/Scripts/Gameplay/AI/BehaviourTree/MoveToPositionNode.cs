using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveToPositionNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;

        [SerializeField]
        [BlackboardValueKey(typeof(float))]
        private string _stoppingDistanceKey;

        [SerializeField]
        [BlackboardValueKey(typeof(Vector3))]
        private string _positionKey;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) ||
                !_blackboard.TryGetValue(_positionKey, out Vector3 position) || 
                !_blackboard.TryGetValue(_stoppingDistanceKey, out float stoppingDistance))
                return BehaviourResult.Failure;
            
            Vector3 delta = position - character.transform.position;
            delta.y = 0;
            
            if (delta.sqrMagnitude <= stoppingDistance * stoppingDistance)
                return BehaviourResult.Success;
            
            character.GetComponent<MoveComponent>().MoveStep(delta.normalized, deltaTime);
            return BehaviourResult.Running;
        }
    }
}