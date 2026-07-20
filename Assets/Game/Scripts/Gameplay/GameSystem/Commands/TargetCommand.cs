using UnityEngine;

namespace SampleGame
{
    public abstract class TargetCommand : ICommand
    {
        public GameObject TargetObject { get; }
        
        protected TargetCommand(GameObject target) => TargetObject = target;
        
        public abstract bool CanExecute();

        public abstract bool Execute();

        public abstract void Cancel();
    }
}