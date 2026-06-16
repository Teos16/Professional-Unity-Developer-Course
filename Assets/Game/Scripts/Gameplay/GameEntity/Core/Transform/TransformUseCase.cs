using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class TransformUseCase
    {
        public static bool LessOrEqualsDistance(this IGameEntity entity, IGameEntity otherEntity, float distance)
        {
            Vector3 point = otherEntity.GetValue(GameEntityAPI.Position).Value;
            return GetDistance(entity, point) <= distance;
        }

        public static bool LessOrEqualsDistance(this IGameEntity entity, Vector3 point, float distance) => 
            GetDistance(entity, point) <= distance;

        public static float GetDistance(this IGameEntity entity, Vector3 position)
        {
            Vector3 currentPosition = entity.GetValue(GameEntityAPI.Position).Value;
            Vector3 distance = position - currentPosition;
            return distance.magnitude;
        }

        public static void SetRandomSpread(this IGameEntity entity, float maxSpreadAngle = 0.25f)
        {
            IVariable<Quaternion> rotation = entity.GetValue(GameEntityAPI.Rotation);

            float spreadX = Random.Range(-maxSpreadAngle, maxSpreadAngle);
            float spreadY = Random.Range(-maxSpreadAngle, maxSpreadAngle);
            
            Quaternion spreadRotation = Quaternion.Euler(spreadX, spreadY, 0);
            
            Quaternion finalRotation = rotation.Value * spreadRotation;
            
            rotation.Value = finalRotation;
        }
    }
}