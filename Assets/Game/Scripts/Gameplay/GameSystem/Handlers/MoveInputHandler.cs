using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveInputHandler : InputHandler
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private InputHandler _next;

        private CommandManager _commandManager;

        private void Start() => _commandManager = _character.GetComponentInChildren<CommandManager>();

        public override void Handle(ref InputContext context)
        {
            if (context.rightClick)
            {
                ICommand command = null;

                if (context.target != null && context.target != _character)
                    command = new MoveToTargetCommand(context.target);
                else if (context.point != null)
                    command = new MoveToPositionCommand(context.point.Value);

                _commandManager.Execute(command, context.enqueueCommand);
            }
            else if (_next)
                _next.Handle(ref context);
        }
    }
}