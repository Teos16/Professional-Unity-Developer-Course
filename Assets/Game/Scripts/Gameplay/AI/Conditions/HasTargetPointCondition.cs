using System;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class HasTargetPointCondition : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        [SerializeField] [BlackboardValueKey(typeof(Vector3))] private string _targetKey;
        
        public bool Invoke() => _blackboard.TryGetValue(_targetKey, out Vector3 target) && target != Vector3.zero;
    }
}