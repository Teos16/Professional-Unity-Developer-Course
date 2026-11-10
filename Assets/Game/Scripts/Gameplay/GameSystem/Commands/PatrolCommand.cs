using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class PatrolCommand : ICommand, IMergeableCommand
    {
        private readonly List<IWaypoint> _waypoints = new();

        public CommandId Id => CommandId.Patrol;

        public GameObject Target { get; }

        public Vector3 Point { get; }

        public PatrolCommand(Vector3 point)
        {
            Point = point;
            _waypoints.Add(new Waypoint(point));
        }

        public PatrolCommand(GameObject target)
        {
            Target = target;
            _waypoints.Add(new EntityWaypoint(target));
        }

        public bool TryMerge(ICommand next)
        {
            if (next is not PatrolCommand patrol)
                return false;

            _waypoints.AddRange(patrol._waypoints);
            return true;
        }

        public void Unpack(Blackboard blackboard)
        {
            GameObject character = blackboard.GetValue(BlackboardAPI.Character);

            _waypoints.Insert(0, new Waypoint(character.transform.position));

            blackboard.SetReferenceValue(BlackboardAPI.Waypoints, _waypoints);
            blackboard.SetPrimitiveValue(BlackboardAPI.WaypointIndex, 1);
        }

        public void Dispose(Blackboard blackboard)
        {
            blackboard.DelValue(BlackboardAPI.Waypoints);
            blackboard.DelValue(BlackboardAPI.WaypointIndex);
        }
    }
}