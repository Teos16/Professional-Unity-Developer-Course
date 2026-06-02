using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public static class MoveUseCase
    {
        public static void MoveStep(this IEntity entity, Vector3 direction, float deltaTime)
        {
            entity.MoveStep(direction, entity.GetMoveSpeed().Value, deltaTime);
        }
        
        public static void MoveStep(this IEntity entity, Vector3 direction, float speed, float deltaTime)
        {
            IVariable<Vector3> position = entity.GetPosition();
            position.Value += direction * speed * deltaTime;
        }

        public static bool IsMoving(this IEntity entity)
        {
            return Time.time - entity.GetMoveTime().Value <= entity.GetMoveDuration().Value;
        }
    }
}