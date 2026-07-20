using UnityEngine;

namespace SampleGame
{
    public interface IWaypoint
    {
        public Vector3 GetPosition { get; }
        public bool IsValid { get; }
    }
}