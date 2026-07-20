using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class NextWaypointNode : BehaviourNode
    {
        [SerializeField] private Blackboard _blackboard;
        
        private IWaypoint _waypoint;
        
        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Waypoints, out List<IWaypoint> waypoints))
                return BehaviourResult.Failure;

            if (!_blackboard.TryGetValue(BlackboardAPI.WaypointIndex, out int currentIndex))
                return BehaviourResult.Failure;
            
            int nextWaypointIndex = GetNextValidWaypointIndex(currentIndex, waypoints);
            _blackboard.SetPrimitiveValue(BlackboardAPI.WaypointIndex, nextWaypointIndex);
            return BehaviourResult.Success;
        }

        private int GetNextValidWaypointIndex(int startIndex, List<IWaypoint> waypoints)
        {
            if (waypoints == null || waypoints.Count == 0)
                return -1;

            if (startIndex < 0 || startIndex >= waypoints.Count)
                startIndex = waypoints.Count - 1;

            int originalCount = waypoints.Count;
            int checkedCount = 0;

            int idx = (startIndex + 1) % waypoints.Count;

            while (checkedCount < originalCount && waypoints.Count > 0)
            {
                if (waypoints[idx].IsValid)
                    return idx;

                waypoints.RemoveAt(idx);
                checkedCount++;

                if (waypoints.Count == 0)
                    return -1;

                if (idx == waypoints.Count)
                    idx = 0;
            }

            return -1;
        }
    }
}