using Modules.AI;

namespace SampleGame
{
    public static class BlackboardReset
    {
        public static void Reset(this Blackboard blackboard)
        {
            blackboard.DelValue(BlackboardAPI.MovementTarget);
            blackboard.DelValue(BlackboardAPI.MovementPosition);
            blackboard.DelValue(BlackboardAPI.FollowTarget);
            blackboard.DelValue(BlackboardAPI.Enemy);
            blackboard.DelValue(BlackboardAPI.AttackPosition);
            blackboard.DelValue(BlackboardAPI.HoldPosition);
            blackboard.DelValue(BlackboardAPI.Waypoints);
            blackboard.DelValue(BlackboardAPI.WaypointIndex);
            blackboard.DelValue(BlackboardAPI.WaypointPosition);
        }
    }
}