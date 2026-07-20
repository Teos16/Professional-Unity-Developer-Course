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

        private void Start()
        {
            _blackboard = GetComponentInChildren<Blackboard>();
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
                    
                    UpdateIdleState();
                    
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
        }

        private void UpdateIdleState()
        {
            if (_blackboard == null)
                return;

            bool shouldBeIdle = !_isExecuting && _queue.Count == 0;
            
            if (!_blackboard.TryGetValue(BlackboardAPI.IsIdle, out bool currentIsIdle) || currentIsIdle != shouldBeIdle) 
                _blackboard.SetPrimitiveValue(BlackboardAPI.IsIdle, shouldBeIdle);
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