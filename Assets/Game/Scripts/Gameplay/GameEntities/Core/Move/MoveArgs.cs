using UnityEngine;

namespace Game.Gameplay
{
    public struct MoveArgs
    {
        public Vector3 direction;
        public float deltaTime;

        public MoveArgs(Vector3 direction, float deltaTime)
        {
            this.direction = direction;
            this.deltaTime = deltaTime;
        }
    }
}