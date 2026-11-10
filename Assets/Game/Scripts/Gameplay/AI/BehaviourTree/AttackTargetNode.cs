using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackTargetNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character) ||
                !_blackboard.TryGetValue(BlackboardAPI.AttackTarget, out GameObject target))
                return BehaviourResult.Failure;

            if (!target.IsAlive())
                return BehaviourResult.Success;

            character.Fight(target,
                _blackboard.GetValue(BlackboardAPI.MinRangeDistance),
                _blackboard.GetValue(BlackboardAPI.MaxRangeDistance),
                _blackboard.GetValue(BlackboardAPI.StoppingAngle),
                deltaTime);

            return BehaviourResult.Running;
        }
    }
}
