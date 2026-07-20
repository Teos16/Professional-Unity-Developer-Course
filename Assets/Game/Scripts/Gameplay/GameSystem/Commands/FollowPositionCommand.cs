using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class FollowPositionCommand : PositionCommand
    {
        private readonly Blackboard _blackboard;

        public FollowPositionCommand(Blackboard blackboard, Vector3 target) : base(target) 
            => _blackboard = blackboard;

        public override bool CanExecute() => _blackboard != null 
                                             && TargetPosition.HasValue;

        public override bool Execute()
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.MovementPosition, out Vector3 current) 
                || current != TargetPosition.Value)
            {
                _blackboard.SetPrimitiveValue(BlackboardAPI.MovementPosition, TargetPosition.Value);
                return false;
            }

            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character))
                return false;

            if (!_blackboard.TryGetValue(BlackboardAPI.StoppingDistance, out float stoppingDistance))
                return false;

            Vector3 delta = TargetPosition.Value - character.transform.position;
            delta.y = 0;

            if (delta.sqrMagnitude <= stoppingDistance * stoppingDistance)
            {
                _blackboard.DelValue(BlackboardAPI.MovementPosition);
                return true;
            }

            return false;
        }

        public override void Cancel() => _blackboard.DelValue(BlackboardAPI.MovementPosition);
    }
}