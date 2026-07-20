using UnityEngine;

namespace SampleGame
{
    public abstract class PositionCommand : ICommand
    {
        public Vector3? TargetPosition { get; }
        
        protected PositionCommand(Vector3 targetPosition) => TargetPosition = targetPosition;
        
        public abstract bool CanExecute();

        public abstract bool Execute();

        public abstract void Cancel();
    }
}