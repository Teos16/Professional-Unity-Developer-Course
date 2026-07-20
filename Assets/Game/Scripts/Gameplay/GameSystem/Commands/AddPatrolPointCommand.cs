using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AddPatrolPointCommand : PositionCommand
    {
        private readonly Blackboard _blackboard;
        private readonly Waypoint _waypoint;

        public AddPatrolPointCommand(Blackboard blackboard, Vector3 position) : base(position)
        {
            _blackboard = blackboard;
            _waypoint = new Waypoint(position);
        }

        public override bool CanExecute() => _blackboard != null
                                             && _waypoint != null
                                             && _waypoint.IsValid
                                             && _blackboard.TryGetValue(BlackboardAPI.Waypoints, out List<IWaypoint> _);

        public override bool Execute()
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Waypoints, out List<IWaypoint> waypoints))
                return true;

            waypoints.Add(_waypoint);
            return true;
        }

        public override void Cancel() { }
    }
}