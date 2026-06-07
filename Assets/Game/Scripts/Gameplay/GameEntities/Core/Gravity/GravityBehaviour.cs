using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class GravityBehaviour : IGameEntityInit, IGameEntityFixedTick
    {
        private IVariable<Vector3> _position;
        private IVariable<float> _verticalSpeed;

        public void Init(IGameEntity entity)
        {
            _position = entity.GetPosition();
            _verticalSpeed = entity.GetVerticalSpeed();
        }

        public void FixedTick(IGameEntity entity, float deltaTime)
        {
            float verticalSpeed = _verticalSpeed.Value;
            Vector3 position = _position.Value;

            float gravity = Constants.Gravity;

            if (verticalSpeed < 0f)
                gravity *= 2f;

            verticalSpeed -= gravity * deltaTime;
            position.y += verticalSpeed * deltaTime;

            if (position.y <= 0f)
            {
                position.y = 0f;

                if (verticalSpeed < 0f)
                    verticalSpeed = 0f;
            }

            _verticalSpeed.Value = verticalSpeed;
            _position.Value = position;
        }
    }
}