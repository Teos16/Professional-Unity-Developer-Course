using Atomic.Elements;
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

            IVariable<Quaternion> rotation = entity.GetRotation();
            float rotationSpeed = entity.GetRotationSpeed().Value;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            rotation.Value = Quaternion.RotateTowards(rotation.Value, targetRotation, rotationSpeed * deltaTime);
        }
    }
}