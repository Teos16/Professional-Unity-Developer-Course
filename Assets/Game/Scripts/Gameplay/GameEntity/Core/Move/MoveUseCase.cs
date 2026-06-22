using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        public static void MoveStepWithTransform(this IGameEntity entity, Vector3 direction, float speed, float deltaTime)
        {
            entity.GetValue(GameEntityAPI.Transform).Value.position += direction * speed * deltaTime;
        }

        public static void MoveWithRootMotion(this IGameEntity entity, float speedMultiplier = 1)
        {
            Animator animator = entity.GetValue(GameEntityAPI.Animator).Value;
            IVariable<Transform> transform = entity.GetValue(GameEntityAPI.Transform);
            transform.Value.position += animator.deltaPosition * speedMultiplier;
        }
        
        public static bool IsMoving(this IGameEntity entity) => entity.GetValue(GameEntityAPI.MoveTime).IsPlaying();
    }
}