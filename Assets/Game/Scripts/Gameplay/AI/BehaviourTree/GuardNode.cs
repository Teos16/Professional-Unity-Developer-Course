using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class GuardNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character))
                return BehaviourResult.Failure;

            if (_blackboard.TryGetValue(BlackboardAPI.ClosestEnemy, out GameObject enemy) && enemy)
            {
                character.Fight(enemy,
                    _blackboard.GetValue(BlackboardAPI.MinRangeDistance),
                    _blackboard.GetValue(BlackboardAPI.MaxRangeDistance),
                    _blackboard.GetValue(BlackboardAPI.StoppingAngle),
                    deltaTime);

                return BehaviourResult.Running;
            }

            if (!_blackboard.TryGetValue(BlackboardAPI.GuardPosition, out Vector3 position) ||
                !_blackboard.TryGetValue(BlackboardAPI.StoppingDistance, out float stoppingDistance))
                return BehaviourResult.Failure;

            if (!character.IsWithin(position, stoppingDistance))
                character.MoveTowards(position, deltaTime);

            return BehaviourResult.Running;
        }
    }
}
