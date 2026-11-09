using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveToPositionCommand : ICommand
    {
        public CommandId Id => CommandId.MoveToPosition;
        public Vector3 Position { get; }

        public MoveToPositionCommand(Vector3 position) => Position = position;

        public void Unpack(Blackboard blackboard) => blackboard.SetPrimitiveValue(BlackboardAPI.MovementPosition, Position);

        public void Dispose(Blackboard blackboard) => blackboard.DelValue(BlackboardAPI.MovementPosition);
    }
}