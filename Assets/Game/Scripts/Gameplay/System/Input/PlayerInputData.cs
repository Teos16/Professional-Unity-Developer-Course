using Fusion;
using UnityEngine;

namespace Game
{
    public struct PlayerInputData : INetworkInput
    {
        public Vector2 moveDirection;
    }
}
