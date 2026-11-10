using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackTargetCommand : ICommand
    {
        public CommandId Id => CommandId.AttackTarget;
        public GameObject Target { get; }

        public AttackTargetCommand(GameObject target) => Target = target;

        public void Unpack(Blackboard blackboard) =>
            blackboard.SetReferenceValue(BlackboardAPI.AttackTarget, Target);

        public void Dispose(Blackboard blackboard) =>
            blackboard.DelValue(BlackboardAPI.AttackTarget);
    }
}