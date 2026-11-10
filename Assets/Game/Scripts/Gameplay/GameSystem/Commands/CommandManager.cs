using System;
using System.Collections.Generic;
using Modules.AI;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace SampleGame
{
    public sealed class CommandManager : SerializedMonoBehaviour
    {
        public event Action<ICommand> OnCommandTrigger;

        [OdinSerialize] private Dictionary<CommandId, BehaviourNode> _nodes = new();
        [OdinSerialize] private ICommand _defaultCommand;

        private readonly Queue<ICommand> _queue = new();

        private Blackboard _blackboard;
        private ICommand _current;
        private BehaviourNode _currentNode;
        
        private bool IsIdle => _current == null || _current == _defaultCommand;

        private void Start() => _blackboard = GetComponentInChildren<Blackboard>();

        private void Update()
        {
            if (_current == null || (IsIdle && _queue.Count > 0))
                SwitchToNext();

            if (_current == null)
                return;

            BehaviourResult result = _currentNode.Run(Time.deltaTime);
            if (result != BehaviourResult.Running)
                SwitchToNext();
        }

        public void Execute(ICommand command, bool enqueue = false)
        {
            if (command == null)
                return;

            if (!enqueue)
                Stop();

            _queue.Enqueue(command);
            OnCommandTrigger?.Invoke(command);
        }

        public void Stop()
        {
            _queue.Clear();
            StopCurrent();
        }

        private void SwitchToNext()
        {
            StopCurrent();

            _current = _queue.Count > 0 ? _queue.Dequeue() : _defaultCommand;
            if (_current == null)
                return;

            _currentNode = _nodes[_current.Id];
            _current.Unpack(_blackboard);
        }


        private void StopCurrent()
        {
            if (_current == null)
                return;

            _currentNode.Abort();
            _current.Dispose(_blackboard);
            _current = null;
            _currentNode = null;
        }
    }
}