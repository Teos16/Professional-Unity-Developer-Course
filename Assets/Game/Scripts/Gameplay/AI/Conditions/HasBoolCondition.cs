using System;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class HasBoolCondition : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        [SerializeField] [BlackboardValueKey(typeof(bool))] private string _targetKey;
        
        public bool Invoke() => _blackboard.TryGetValue(_targetKey, out bool _);
    }
}