using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackPositionCommand : PositionCommand
    {
        private readonly Blackboard _blackboard;

        public AttackPositionCommand(Blackboard blackboard, Vector3 position) : base(position)
            => _blackboard = blackboard;

        public override bool CanExecute() => _blackboard != null && TargetPosition.HasValue;

        public override bool Execute()
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.AttackPosition, out Vector3 current)
                || current != TargetPosition.Value)
                _blackboard.SetPrimitiveValue(BlackboardAPI.AttackPosition, TargetPosition.Value);

            if (current != TargetPosition.Value)
                return false;

            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character))
                return false;

            if (!_blackboard.TryGetValue(BlackboardAPI.StoppingDistance, out float stoppingDistance))
                return false;

            Vector3 delta = TargetPosition.Value - character.transform.position;
            delta.y = 0;

            if (delta.sqrMagnitude <= stoppingDistance * stoppingDistance)
            {
                _blackboard.DelValue(BlackboardAPI.AttackPosition);
                return true;
            }

            return false;
        }

        public override void Cancel() => _blackboard.DelValue(BlackboardAPI.AttackPosition);
    }
}