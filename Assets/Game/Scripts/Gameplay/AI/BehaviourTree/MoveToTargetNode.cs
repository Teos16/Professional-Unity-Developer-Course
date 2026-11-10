using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveToTargetNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) ||
                !_blackboard.TryGetValue(BlackboardAPI.MovementTarget, out GameObject target) ||
                !_blackboard.TryGetValue(BlackboardAPI.StoppingDistance, out float stoppingDistance))
                return BehaviourResult.Failure;

            if (!target.IsAlive())
                return BehaviourResult.Failure;

            Vector3 targetPosition = target.transform.position;

            if (character.IsWithin(targetPosition, stoppingDistance))
                return BehaviourResult.Success;

            character.MoveTowards(targetPosition, deltaTime);
            return BehaviourResult.Running;
        }
    }
}
