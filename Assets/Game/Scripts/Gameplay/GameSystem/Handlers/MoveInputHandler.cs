using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveInputHandler : InputHandler
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private InputHandler _next;

        private Blackboard _blackboard;
        private CommandManager _commandManager;

        private void Start()
        {
            _blackboard = _character.GetComponentInChildren<Blackboard>();
            _commandManager = _character.GetComponentInChildren<CommandManager>();
        }

        public override void Handle(ref InputContext context)
        {
            if (context.rightClick)
            {
                ICommand command = null;

                if (context.target != null && context.target != _character)
                    command = new MoveToTargetCommand(_blackboard, context.target);
                else if (context.point != null) 
                    command = new MoveToPositionCommand(_blackboard, context.point.Value);

                if (context.enqueueCommand)
                {
                    _commandManager.Enqueue(command);
                }
                else
                {
                    _commandManager.Clear();
                    _blackboard.Reset();
                    _commandManager.Enqueue(command);
                }
            }
            else if (_next) 
                _next.Handle(ref context);
        }
    }
}