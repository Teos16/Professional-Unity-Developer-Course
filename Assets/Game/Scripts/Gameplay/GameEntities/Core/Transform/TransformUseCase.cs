using UnityEngine;

namespace Game.Gameplay
{
    public static class TransformUseCase
    {
        public static bool LessOrEqualsDistance(this IGameEntity entity, Vector3 point, float distance) => 
            GetDistance(entity, point) <= distance;

        public static float GetDistance(this IGameEntity entity, Vector3 position)
        {
            Vector3 currentPosition = entity.GetPosition().Value;
            Vector3 distance = position - currentPosition;
            return distance.magnitude;
        }

        public static void Teleport(this IGameEntity entity, Vector3 point)
        {
            entity.GetPosition().Value = point;
        }
    }
}