using System;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class HasTargetCondition : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        [SerializeField] [BlackboardValueKey(typeof(GameObject))] private string _targetKey;
        
        public bool Invoke() => 
            _blackboard.TryGetValue(_targetKey, out GameObject target) && target && target.activeInHierarchy;
    }
}