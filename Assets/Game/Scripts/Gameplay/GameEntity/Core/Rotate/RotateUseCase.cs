using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class RotateUseCase
    {
        public static void RotateStep(this IGameEntity entity, RotateArgs args) => 
            entity.RotateStep(args.direction, args.deltaTime);

        public static void RotateStep(this IGameEntity entity, Vector3 direction, float deltaTime)
        {
            if (direction == Vector3.zero)
                return;

            IVariable<Quaternion> rotation = entity.GetValue(GameEntityAPI.Rotation);
            float rotationSpeed = entity.GetValue(GameEntityAPI.RotationSpeed).Value;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rotation.Value = Quaternion.Slerp(rotation.Value, targetRotation, deltaTime * rotationSpeed);
        }
    }
}