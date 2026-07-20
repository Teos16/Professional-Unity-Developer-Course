using System;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class IsIdleCondition : ICondition
    {
        [SerializeField] private Blackboard _blackboard;
        
        public bool Invoke()
        {
            if(_blackboard.TryGetValue(BlackboardAPI.IsIdle, out bool isIdle))
                return isIdle;
            
            return false;
        }
    }
}