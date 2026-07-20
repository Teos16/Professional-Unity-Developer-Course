using UnityEngine;

namespace SampleGame
{
    public sealed class Waypoint : IWaypoint
    {
        public Waypoint(Vector3 position) => GetPosition = position;

        public Vector3 GetPosition { get; }
        public bool IsValid => true;
    }
}