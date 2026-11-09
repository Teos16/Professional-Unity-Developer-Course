using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class HoldPositionHandler : InputHandler
    {
        [SerializeField] private KeyCode _keyCode = KeyCode.H;
        [SerializeField] private GameObject _character;
        [SerializeField] private InputHandler _next;

        private CommandManager _commandManager;

        private void Start() => _commandManager = _character.GetComponentInChildren<CommandManager>();

        public override void Handle(ref InputContext context)
        {
            if (_next)
                _next.Handle(ref context);
        }
    }
}