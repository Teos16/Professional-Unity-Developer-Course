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

            Transform transform = entity.GetValue(GameEntityAPI.Transform).Value;
            float rotationSpeed = entity.GetValue(GameEntityAPI.RotationSpeed).Value;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, deltaTime * rotationSpeed);
        }
    }
}