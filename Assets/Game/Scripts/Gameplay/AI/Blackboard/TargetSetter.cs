using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class TargetSetter : MonoBehaviour
    {
        [SerializeField]
        private Blackboard _blackboard;
        
        public void SetTarget(GameObject target) => 
            _blackboard.SetReferenceValue(BlackboardAPI.FollowTarget, target);
    }
}