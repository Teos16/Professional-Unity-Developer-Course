using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackPositionCommand : ICommand
    {
        public CommandId Id => CommandId.AttackPosition;
        public Vector3 Position { get; }

        public AttackPositionCommand(Vector3 position) => Position = position;

        public void Unpack(Blackboard blackboard) => blackboard.SetPrimitiveValue(BlackboardAPI.AttackPosition, Position);

        public void Dispose(Blackboard blackboard) => blackboard.DelValue(BlackboardAPI.AttackPosition);
    }
}