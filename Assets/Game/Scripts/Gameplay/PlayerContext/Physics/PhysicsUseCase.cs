using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class PhysicsUseCase
    {
        public static bool RaycastGround(this IPlayerContext context, Vector2 screenPosition, out Vector3 point)
        {
            Camera camera = context.GetValue(PlayerContextAPI.Camera);
            Ray ray = camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.CompareTag("Ground"))
            {
                point = hit.point;
                return true;
            }

            point = default;
            return false;
        }

        public static bool RaycastTarget(this IPlayerContext context, Vector2 screenPosition, out IGameEntity target)
        {
            Camera camera = context.GetValue(PlayerContextAPI.Camera);
            Ray ray = camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.TryGetComponent(out target))
                return true;

            target = null;
            return false;
        }
    }
}