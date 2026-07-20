using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class FollowTargetCommand : TargetCommand
    {
        private readonly Blackboard _blackboard;

        public FollowTargetCommand(Blackboard blackboard, GameObject target) : base(target) 
            => _blackboard = blackboard;

        public override bool CanExecute() => _blackboard != null 
                                             && TargetObject != null 
                                             && TargetObject.activeInHierarchy;

        public override bool Execute()
        {
            if (!TargetObject || !TargetObject.activeInHierarchy)
            {
                _blackboard.DelValue(BlackboardAPI.FollowTarget);
                return true;
            }

            if (!_blackboard.TryGetValue(BlackboardAPI.FollowTarget, out GameObject current) || current != TargetObject)
                _blackboard.SetReferenceValue(BlackboardAPI.FollowTarget, TargetObject);

            return false;
        }

        public override void Cancel() => _blackboard.DelValue(BlackboardAPI.FollowTarget);
    }
}