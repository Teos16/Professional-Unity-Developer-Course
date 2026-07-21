using System;
using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame 
{
    public class CommandManager : MonoBehaviour 
    {
        public event Action<ICommand> OnCommandTrigger;
        
        private readonly Queue<ICommand> _queue = new();
        private ICommand _currentCommand;
        private bool _isExecuting;

        private Blackboard _blackboard;
        private GameObject _character;

        private void Start()
        {
            _blackboard = GetComponentInChildren<Blackboard>();
            _character = gameObject;
        }

        private void Update() 
        {
            if (_isExecuting && _currentCommand != null)
            {
                bool isFinished = _currentCommand.Execute(); 
                if (isFinished) 
                {
                    _isExecuting = false;
                    _currentCommand = null;
                }
                
                UpdateIdleState();
                return;
            }

            while (!_isExecuting && _queue.TryPeek(out ICommand nextCommand)) 
            {
                if (nextCommand.CanExecute()) 
                {
                    _currentCommand = _queue.Dequeue();
                    OnCommandTrigger?.Invoke(_currentCommand);

                    _isExecuting = true;
                    
                    bool isFinished = _currentCommand.Execute(); 
                    if (isFinished) 
                    {
                        _isExecuting = false;
                        _currentCommand = null;
                    }
                    
                    break;
                }
                else
                {
                    _queue.Dequeue(); 
                }
            }
            
            UpdateIdleState();
        }

        private void UpdateIdleState()
        {
            if (_blackboard == null || _character == null)
                return;

            bool shouldBeIdle = !_isExecuting && _queue.Count == 0;

            if (shouldBeIdle)
            {
                if(!_blackboard.TryGetValue(BlackboardAPI.IdlePosition, out Vector3 _))
                    _blackboard.SetPrimitiveValue(BlackboardAPI.IdlePosition, _character.transform.position);
            }
            else
                _blackboard.DelValue(BlackboardAPI.IdlePosition);
        }

        public void Enqueue(ICommand command) 
        {
            if (command == null) return;
            
            _queue.Enqueue(command);
            OnCommandTrigger?.Invoke(command);
        }

        public void Execute(ICommand command)
        {
            if(command == null) 
                return;

            if (command.CanExecute())
            {
                command.Execute();
                OnCommandTrigger?.Invoke(command);
            }
        }

        public void Clear() 
        {
            if (_isExecuting && _currentCommand != null) 
            {
                _currentCommand.Cancel();
            }
            
            _queue.Clear();
            _isExecuting = false;
            _currentCommand = null;
            
            UpdateIdleState();
        }
    }
}