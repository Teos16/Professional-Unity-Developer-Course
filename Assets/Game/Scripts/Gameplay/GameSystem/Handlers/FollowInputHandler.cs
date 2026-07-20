using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class FollowInputHandler : InputHandler
    {
        [SerializeField] private KeyCode _keyCode = KeyCode.F;
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
            if (Input.GetKey(_keyCode) && context.leftClick)
            {
                ICommand command = null;

                if (context.point != null)
                    command = new FollowPositionCommand(_blackboard, context.point.Value);
                else if (context.target != null && context.target != _character) 
                    command = new FollowTargetCommand(_blackboard, context.target);
                
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