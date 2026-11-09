using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class FollowCommand : ICommand
    {
        public CommandId Id => CommandId.Follow;
        public GameObject Target { get; }

        public FollowCommand(GameObject target) => Target = target;

        public void Unpack(Blackboard blackboard) => blackboard.SetReferenceValue(BlackboardAPI.FollowTarget, Target);

        public void Dispose(Blackboard blackboard) => blackboard.DelValue(BlackboardAPI.FollowTarget);
    }
}