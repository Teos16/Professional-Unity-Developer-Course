using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public static class BulletUseCase
    {
        public static void SpawnBullet(this GameContext context, Vector3 position, Quaternion rotation)
        {
            SceneEntityPool bulletPool = context.GetBulletPool();
            SceneEntity bullet = bulletPool.Rent();
            bullet.GetPosition().Value = position;
            bullet.GetRotation().Value = rotation;
            bullet.GetRespawnAction().Invoke();
        }

        public static void DespawnBullet(this GameContext context, SceneEntity bullet)
        {
            context.GetBulletPool().Return(bullet);
        }
    }
}