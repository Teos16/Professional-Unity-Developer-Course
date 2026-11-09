using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveToTargetCommand : ICommand
    {
        public CommandId Id => CommandId.MoveToTarget;
        public GameObject Target { get; }

        public MoveToTargetCommand(GameObject target) => Target = target;

        public void Unpack(Blackboard blackboard) => blackboard.SetReferenceValue(BlackboardAPI.MovementTarget, Target);

        public void Dispose(Blackboard blackboard) => blackboard.DelValue(BlackboardAPI.MovementTarget);
    }
}