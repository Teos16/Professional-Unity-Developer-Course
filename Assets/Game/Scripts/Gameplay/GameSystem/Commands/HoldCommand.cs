using Modules.AI;

namespace SampleGame
{
    public sealed class HoldCommand : ICommand
    {
        public CommandId Id => CommandId.Hold;

        public void Unpack(Blackboard blackboard) { }

        public void Dispose(Blackboard blackboard) { }
    }
}