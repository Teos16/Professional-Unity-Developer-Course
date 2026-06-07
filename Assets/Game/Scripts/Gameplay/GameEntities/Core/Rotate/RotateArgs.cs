using UnityEngine;

namespace Game.Gameplay
{
    public struct RotateArgs
    {
        public Vector3 direction;
        public float deltaTime;

        public RotateArgs(Vector3 direction, float deltaTime)
        {
            this.direction = direction;
            this.deltaTime = deltaTime;
        }
    }
}