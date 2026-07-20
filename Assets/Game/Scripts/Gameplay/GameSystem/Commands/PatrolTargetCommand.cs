using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    public sealed class PatrolTargetCommand : TargetCommand
    {
        private readonly Blackboard _blackboard;
        private readonly EntityWaypoint _waypoint;
        private readonly GameObject _character;

        public PatrolTargetCommand(Blackboard blackboard, GameObject character, GameObject target)
            : base(target)
        {
            _blackboard = blackboard;
            _character = character;
            _waypoint = new EntityWaypoint(target);
        }

        public override bool CanExecute() => _blackboard != null
                                             && _character != null
                                             && _waypoint != null
                                             && _waypoint.IsValid;

        public override bool Execute()
        {
            if (!_blackboard.TryGetValue(BlackboardAPI.Waypoints, out List<IWaypoint> boardWaypoints) 
                || boardWaypoints[1] != _waypoint)
            {
                List<IWaypoint> waypoints = new List<IWaypoint>
                {
                    new Waypoint(_character.transform.position),
                    _waypoint
                };

                _blackboard.SetReferenceValue(BlackboardAPI.Waypoints, waypoints);
                _blackboard.SetPrimitiveValue(BlackboardAPI.WaypointIndex, 0);
                _blackboard.SetPrimitiveValue(BlackboardAPI.WaypointPosition, waypoints[0].GetPosition);
            }

            return false;
        }

        public override void Cancel()
        {
            _blackboard.DelValue(BlackboardAPI.Waypoints);
            _blackboard.DelValue(BlackboardAPI.WaypointIndex);
            _blackboard.DelValue(BlackboardAPI.WaypointPosition);
        }
    }
}