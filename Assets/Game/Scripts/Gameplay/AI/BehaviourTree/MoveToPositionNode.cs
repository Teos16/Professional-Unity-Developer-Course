using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveToPositionNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;
        
        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) ||
                !_blackboard.TryGetValue(BlackboardAPI.MovementPosition, out Vector3 position) ||
                !_blackboard.TryGetValue(BlackboardAPI.StoppingDistance, out float stoppingDistance))
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