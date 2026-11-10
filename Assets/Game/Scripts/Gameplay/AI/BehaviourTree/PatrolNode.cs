using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class PatrolNode : BehaviourNode
    {
        [SerializeField]
        private Blackboard _blackboard;

        protected override BehaviourResult OnUpdate(float deltaTime)
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Character, out GameObject character))
                return BehaviourResult.Failure;

            if (_blackboard.TryGetValue(BlackboardAPI.ClosestEnemy, out GameObject enemy) && enemy)
            {
                character.Fight(enemy,
                    _blackboard.GetValue(BlackboardAPI.MinRangeDistance),
                    _blackboard.GetValue(BlackboardAPI.MaxRangeDistance),
                    _blackboard.GetValue(BlackboardAPI.StoppingAngle),
                    deltaTime);

                return BehaviourResult.Running;
            }

            if (!_blackboard.TryGetValue(BlackboardAPI.Waypoints, out List<IWaypoint> waypoints) ||
                !_blackboard.TryGetValue(BlackboardAPI.WaypointIndex, out int index) ||
                !_blackboard.TryGetValue(BlackboardAPI.StoppingDistance, out float stoppingDistance))
                return BehaviourResult.Failure;

            if (waypoints.Count == 0)
                return BehaviourResult.Failure;

            index %= waypoints.Count;
            IWaypoint current = waypoints[index];

            waypoints.RemoveAll(waypoint => !waypoint.IsValid);
            if (waypoints.Count == 0)
                return BehaviourResult.Failure;

            int currentIndex = waypoints.IndexOf(current);
            index = currentIndex >= 0 ? currentIndex : index % waypoints.Count;

            Vector3 destination = waypoints[index].GetPosition;

            if (character.IsWithin(destination, stoppingDistance))
                index = (index + 1) % waypoints.Count;
            else
                character.MoveTowards(destination, deltaTime);

            _blackboard.SetPrimitiveValue(BlackboardAPI.WaypointIndex, index);
            return BehaviourResult.Running;
        }
    }
}
