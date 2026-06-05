using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class BulletUseCase
    {
        public static void SpawnBullet(this IGameContext gameContext, Vector3 position, Quaternion rotation, TeamType team)
        {
            IEntityPool<IGameEntity> bulletPool = gameContext.GetBulletPool();
            IGameEntity bullet = bulletPool.Rent();
            bullet.GetPosition().Value = position;
            bullet.GetRotation().Value = rotation;
            bullet.GetTeam().Value = team;
            bullet.GetRespawnAction().Invoke();
        }

        public static void DespawnBullet(this IGameContext gameContext, IGameEntity bullet)
        {
            gameContext.GetBulletPool().Return(bullet);
        }
    }
}