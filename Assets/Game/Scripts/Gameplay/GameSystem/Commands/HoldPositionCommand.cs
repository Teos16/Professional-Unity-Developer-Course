using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public class HoldPositionCommand : TargetCommand
    {
        private readonly Blackboard _blackboard;

        public HoldPositionCommand(Blackboard blackboard, GameObject character) : base(character) 
            => _blackboard = blackboard;

        public override bool CanExecute() => _blackboard != null 
                                             && TargetObject != null 
                                             && TargetObject.activeInHierarchy;

        public override bool Execute()
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.HoldPosition, out bool current) || !current) 
                _blackboard.SetPrimitiveValue(BlackboardAPI.HoldPosition, true);

            return false;
        }

        public override void Cancel() => _blackboard.DelValue(BlackboardAPI.HoldPosition);
    }
}