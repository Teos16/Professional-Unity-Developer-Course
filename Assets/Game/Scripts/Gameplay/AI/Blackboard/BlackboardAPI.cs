using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    [BlackboardAPI]
    public static class BlackboardAPI
    {
        // Idle
        public static readonly BlackboardValueKey<bool> IsIdle = new(nameof(IsIdle));
        
        // GameObjects
        public static readonly BlackboardValueKey<GameObject> Character = new(nameof(Character));
        public static readonly BlackboardValueKey<GameObject> FollowTarget = new(nameof(FollowTarget));
        public static readonly BlackboardValueKey<GameObject> MovementTarget = new(nameof(MovementTarget));
        public static readonly BlackboardValueKey<GameObject> Enemy = new(nameof(Enemy));
        
        // Combat
        public static readonly BlackboardValueKey<Vector3> AttackPosition = new(nameof(AttackPosition));
        public static readonly BlackboardValueKey<float> MinRangeDistance = new(nameof(MinRangeDistance));
        public static readonly BlackboardValueKey<float> MaxRangeDistance = new(nameof(MaxRangeDistance));

        // Patrol & Hold
        public static readonly BlackboardValueKey<List<IWaypoint>> Waypoints = new(nameof(Waypoints)); 
        public static readonly BlackboardValueKey<int> WaypointIndex = new(nameof(WaypointIndex));
        public static readonly BlackboardValueKey<Vector3> WaypointPosition = new(nameof(WaypointPosition));
        public static readonly BlackboardValueKey<bool> HoldPosition = new(nameof(HoldPosition));

        // Movement
        public static readonly BlackboardValueKey<Vector3> MovementPosition = new(nameof(MovementPosition));
        public static readonly BlackboardValueKey<float> StoppingDistance = new(nameof(StoppingDistance));
        public static readonly BlackboardValueKey<float> StoppingAngle = new(nameof(StoppingAngle));
        
        // Sensing
        public static readonly BlackboardValueKey<Collider[]> ColliderBuffer = new(nameof(ColliderBuffer));
        public static readonly BlackboardValueKey<int> ColliderCount = new(nameof(ColliderCount));
    }
}