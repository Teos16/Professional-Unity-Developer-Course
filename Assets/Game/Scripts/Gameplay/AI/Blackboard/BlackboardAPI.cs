using System.Collections.Generic;
using Modules.AI;
using UnityEngine;

namespace SampleGame
{
    [BlackboardAPI]
    public static class BlackboardAPI
    {
        // GameObjects
        public static readonly BlackboardValueKey<GameObject> Character = new(nameof(Character));
        public static readonly BlackboardValueKey<GameObject> FollowTarget = new(nameof(FollowTarget));
        public static readonly BlackboardValueKey<GameObject> MovementTarget = new(nameof(MovementTarget));
        public static readonly BlackboardValueKey<GameObject> AttackTarget = new(nameof(AttackTarget));
        
        // Combat
        public static readonly BlackboardValueKey<Vector3> AttackPosition = new(nameof(AttackPosition));
        public static readonly BlackboardValueKey<float> MinRangeDistance = new(nameof(MinRangeDistance));
        public static readonly BlackboardValueKey<float> MaxRangeDistance = new(nameof(MaxRangeDistance));

        // Patrol & Hold
        public static readonly BlackboardValueKey<Vector3> GuardPosition = new(nameof(GuardPosition));
        public static readonly BlackboardValueKey<List<IWaypoint>> Waypoints = new(nameof(Waypoints)); 
        public static readonly BlackboardValueKey<int> WaypointIndex = new(nameof(WaypointIndex));

        // Movement
        public static readonly BlackboardValueKey<Vector3> MovementPosition = new(nameof(MovementPosition));
        public static readonly BlackboardValueKey<float> StoppingDistance = new(nameof(StoppingDistance));
        public static readonly BlackboardValueKey<float> StoppingAngle = new(nameof(StoppingAngle));
        
        // Sensing
        public static readonly BlackboardValueKey<GameObject> ClosestEnemy = new(nameof(ClosestEnemy));
        public static readonly BlackboardValueKey<Collider[]> ColliderBuffer = new(nameof(ColliderBuffer));
        public static readonly BlackboardValueKey<int> ColliderCount = new(nameof(ColliderCount));
    }
}