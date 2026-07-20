using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class StopCommandHandler : InputHandler
    {
        [SerializeField] private KeyCode _keyCode = KeyCode.S;
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
            if (Input.GetKeyDown(_keyCode))
            {
                _commandManager.Clear();
                _blackboard.Reset();
            }
            else if (_next)
                _next.Handle(ref context);
        }
    }
}