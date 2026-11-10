using System;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class GuardCommand : ICommand
    {
        public CommandId Id => CommandId.Guard;

        public void Unpack(Blackboard blackboard)
        {
            GameObject character = blackboard.GetValue(BlackboardAPI.Character);
            blackboard.SetPrimitiveValue(BlackboardAPI.GuardPosition, character.transform.position);
        }

        public void Dispose(Blackboard blackboard) => blackboard.DelValue(BlackboardAPI.GuardPosition);
    }
}