using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public class MoveToTargetCommand : TargetCommand 
    {
        private readonly Blackboard _blackboard;

        public MoveToTargetCommand(Blackboard blackboard, GameObject target) : base(target) => _blackboard = blackboard;

        public override bool CanExecute() => _blackboard != null 
                                             && TargetObject != null 
                                             && TargetObject.activeInHierarchy;

        public override bool Execute() 
        {
            bool hasValue = _blackboard.TryGetValue(BlackboardAPI.MovementTarget, out GameObject currentTarget);

            if (!hasValue || currentTarget != TargetObject) 
            {
                _blackboard.SetReferenceValue(BlackboardAPI.MovementTarget, TargetObject);
                return false; 
            }

            if (currentTarget == TargetObject)
                return false;

            return true; 
        }
        
        public override void Cancel() => _blackboard.DelValue(BlackboardAPI.MovementTarget);
    }
}