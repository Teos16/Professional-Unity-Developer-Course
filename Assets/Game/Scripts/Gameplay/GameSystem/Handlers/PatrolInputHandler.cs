using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class PatrolInputHandler : InputHandler
    {
        [SerializeField] private KeyCode _keyCode = KeyCode.P;
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
                bool isPatrolling = _blackboard.TryGetValue(BlackboardAPI.Waypoints, out _);

                if (context.target != null && context.target != _character)
                    HandleTarget(context, isPatrolling);
                else if (context.point != null)
                    HandlePoint(context, isPatrolling);
            }
            else if (_next)
                _next.Handle(ref context);
        }

        private void HandleTarget(InputContext context, bool isPatrolling)
        {
            if (context.enqueueCommand)
            {
                if (isPatrolling)
                {
                    AddPatrolTargetCommand add = new(_blackboard, context.target);
                    if(add.CanExecute())
                        _commandManager.Execute(add);
                }
                else
                    _commandManager.Enqueue(
                        new PatrolTargetCommand(_blackboard, _character, context.target));
            }
            else
            {
                _commandManager.Clear();
                _blackboard.Reset();
                _commandManager.Enqueue(
                    new PatrolTargetCommand(_blackboard, _character, context.target));
            }
        }

        private void HandlePoint(InputContext context, bool isPatrolling)
        {
            if (context.enqueueCommand)
            {
                if (isPatrolling)
                {
                    AddPatrolPointCommand add = new AddPatrolPointCommand(_blackboard, context.point.Value);
                    if(add.CanExecute())
                        _commandManager.Execute(add);
                }
                else
                    _commandManager.Enqueue(
                        new PatrolPositionCommand(_blackboard, _character, context.point.Value));
            }
            else
            {
                _commandManager.Clear();
                _blackboard.Reset();
                _commandManager.Enqueue(
                    new PatrolPositionCommand(_blackboard, _character, context.point.Value));
            }
        }
    }
}