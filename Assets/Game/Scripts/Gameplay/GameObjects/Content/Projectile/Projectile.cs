using Fusion;
using UnityEngine;

namespace Game
{
    public struct Projectile : INetworkStruct
    {
        public int startTick;
        public Vector3 startPosition;
        public Quaternion startRotation;

        public bool IsAlive => startTick > 0;
        public Vector3 StartDirection => startRotation * Vector3.forward;
    }
}
