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

            if (character.IsWithin(position, stoppingDistance))
                return BehaviourResult.Success;

            character.MoveTowards(position, deltaTime);
            return BehaviourResult.Running;
        }
    }
}
