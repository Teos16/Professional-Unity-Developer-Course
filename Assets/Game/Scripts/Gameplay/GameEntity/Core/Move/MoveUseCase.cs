using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        public static void MoveStepWithTransform(this IGameEntity entity, float speed, float deltaTime)
        {
            Quaternion rotation = entity.GetValue(GameEntityAPI.Rotation).Value;
            Vector3 direction = entity.GetValue(GameEntityAPI.MoveDirection).Value;
            direction = rotation * direction;
            entity.GetValue(GameEntityAPI.Position).Value += direction * speed * deltaTime;
        }

        public static void MoveWithRootMotion(this IGameEntity entity, float speedMultiplier = 1)
        {
            Animator animator = entity.GetValue(GameEntityAPI.Animator).Value;
            IVariable<Vector3> position = entity.GetValue(GameEntityAPI.Position);
            position.Value += animator.deltaPosition * speedMultiplier;
        }
        
        public static bool IsMoving(this IGameEntity entity) => 
            entity.GetValue(GameEntityAPI.MoveDirection).Value != Vector3.zero;
    }
}