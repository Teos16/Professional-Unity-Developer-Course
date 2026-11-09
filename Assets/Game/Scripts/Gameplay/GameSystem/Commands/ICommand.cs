using Modules.AI;

namespace SampleGame
{
    public interface ICommand
    {
        CommandId Id { get; }

        void Unpack(Blackboard blackboard);

        void Dispose(Blackboard blackboard);
    }
}