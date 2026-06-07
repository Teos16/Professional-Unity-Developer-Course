using UnityEngine;

namespace Game.Gameplay
{
    public static class MoveUseCase
    {
        public static void MoveStepForward(this IGameEntity entity, float speed, float deltaTime)
        {
            Vector3 direction = entity.GetRotation().Value * Vector3.forward;
            entity.MoveStep(direction, speed, deltaTime);
        }

        public static void MoveStepWithObstacle(
            this IGameEntity entity,
            Vector3 direction,
            float speed,
            float deltaTime,
            Vector3 offset,
            float checkObstacleDistance,
            LayerMask obstacleLayerMask
        )
        {
            Vector3 origin = entity.GetPosition().Value;

            bool hasObstacle = Physics.Raycast(
                origin + offset,
                direction,
                out RaycastHit hit,
                checkObstacleDistance,
                obstacleLayerMask,
                QueryTriggerInteraction.Ignore
            );

            if (!hasObstacle)
            {
                entity.MoveStep(direction, speed, deltaTime);
                return;
            }
            

            Vector3 slideDirection = Vector3.ProjectOnPlane(direction, hit.normal).normalized;
            bool hasSideObstacle = Physics.Raycast(
                origin + offset,
                slideDirection,
                checkObstacleDistance,
                obstacleLayerMask,
                QueryTriggerInteraction.Ignore
            );
            
            if (!hasSideObstacle && slideDirection != Vector3.zero) 
                entity.MoveStep(slideDirection, speed, deltaTime);
        }

        public static void MoveStep(this IGameEntity entity, Vector3 direction, float speed, float deltaTime)
        {
            entity.GetPosition().Value += direction * speed * deltaTime;
        }

        public static bool IsNotMoving(this IGameEntity entity) =>
            !entity.IsMoving();

        public static bool IsMoving(this IGameEntity entity) => entity.GetMoveTime().IsPlaying();
    }
}