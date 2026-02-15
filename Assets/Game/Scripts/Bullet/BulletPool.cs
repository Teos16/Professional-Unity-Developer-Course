using System.Collections.Generic;
using Modules.Utils;
using UnityEngine;

namespace Game.Bullet
{
    public sealed class BulletPool : MonoBehaviour
    {
        private const int POOL_CAPACITY_PER_TEAM = 100;
        
        [SerializeField] private BulletFactory _factory;
        [SerializeField] private TransformBounds _levelBounds;

        private readonly Dictionary<TeamType, Stack<Bullet>> _teamsWithBulletStacks = new();

        private void Start()
        {
            foreach (TeamType team in new List<TeamType>() { TeamType.Player , TeamType.Enemy})
                _teamsWithBulletStacks.Add(team, new Stack<Bullet>());
            
            for (int i = 0; i < POOL_CAPACITY_PER_TEAM; i++)
            {
                SpawnDefaultBullets(TeamType.Enemy);
                SpawnDefaultBullets(TeamType.Player);
            }
        }

        private void SpawnDefaultBullets(TeamType team)
        {
            Bullet bullet = _factory.SpawnDefaultBullet(team); 
            bullet.gameObject.SetActive(false);
            bullet.OnDisabled += Return;
            _teamsWithBulletStacks[team].Push(bullet);
        }

        public Bullet Rent(Vector2 position, Vector2 direction, TeamType team)
        {
            if (_teamsWithBulletStacks[team].TryPop(out Bullet bullet) && bullet.Team == team)
            {
                bullet.Initialize(position, direction, _levelBounds);
                return bullet;
            }

            var spawnedBullet = _factory.SpawnBullet(position, direction, team);
            spawnedBullet.OnDisabled += Return;
            return spawnedBullet;
        }

        public void Return(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            _teamsWithBulletStacks[bullet.Team].Push(bullet);
        }
    }
}