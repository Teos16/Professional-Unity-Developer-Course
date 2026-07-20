using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AssignWaypointNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;
        
        [SerializeField]
        [BlackboardValueKey(typeof(Vector3))]
        private string _positionKey;
        
        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Waypoints, out List<IWaypoint> waypoints) ||
                !_blackboard.TryGetValue(_positionKey, out Vector3 position) ||
                !_blackboard.TryGetValue(BlackboardAPI.WaypointIndex, out int index) ||
                index < 0 || index >= waypoints.Count)
                return BehaviourResult.Failure;

            Vector3 destination = waypoints[index].GetPosition;
            _blackboard.SetPrimitiveValue(_positionKey, destination);
            return BehaviourResult.Success;
        }
    }
}