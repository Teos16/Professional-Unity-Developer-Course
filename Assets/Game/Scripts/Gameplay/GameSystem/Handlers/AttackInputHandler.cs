using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AttackInputHandler : InputHandler
    {
        [SerializeField] private KeyCode _keyCode = KeyCode.A;
        [SerializeField] private GameObject _character;
        [SerializeField] private InputHandler _next;

        private CommandManager _commandManager;

        private void Start() => _commandManager = _character.GetComponentInChildren<CommandManager>();

        public override void Handle(ref InputContext context)
        {
            if (Input.GetKey(_keyCode) && context.leftClick)
            {
                ICommand command = null;

                if (context.target != null && context.target != _character)
                    command = new AttackTargetCommand(context.target);
                else if (context.point != null)
                    command = new AttackPositionCommand(context.point.Value);

                _commandManager.Execute(command, context.enqueueCommand);
            }
            else if (_next)
                _next.Handle(ref context);
        }
    }
}