using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class AddPatrolTargetCommand : TargetCommand
    {
        private readonly Blackboard _blackboard;
        private readonly EntityWaypoint _waypoint;

        public AddPatrolTargetCommand(Blackboard blackboard, GameObject target)
            : base(target)
        {
            _blackboard = blackboard;
            _waypoint = new EntityWaypoint(target);
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