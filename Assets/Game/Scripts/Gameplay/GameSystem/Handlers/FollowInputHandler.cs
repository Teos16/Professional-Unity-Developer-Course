using UnityEngine;

namespace SampleGame
{
    public sealed class FollowInputHandler : InputHandler
    {
        [SerializeField] private KeyCode _keyCode = KeyCode.F;
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
                    command = new FollowCommand(context.target);
                else if (context.point != null)
                    command = new MoveToPositionCommand(context.point.Value);

                _commandManager.Execute(command, context.enqueueCommand);
            }
            else if (_next)
                _next.Handle(ref context);
        }
    }
}