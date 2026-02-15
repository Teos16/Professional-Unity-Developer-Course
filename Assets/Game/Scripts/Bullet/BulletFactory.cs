using AYellowpaper.SerializedCollections;
using Modules.Utils;
using UnityEngine;

namespace Game.Bullet
{
    public sealed class BulletFactory : MonoBehaviour
    {
        [SerializeField] private SerializedDictionary<TeamType, Bullet> _teamToBulletPrefab;
        [SerializeField] private TransformBounds _levelBounds;
        [SerializeField] private Transform _container;

        private readonly Vector2 _defaultPosition = Vector2.zero;
        private readonly Vector2 _defaultDirection = Vector2.up;
        
        public Bullet SpawnBullet(Vector2 position, Vector2 direction, TeamType team)
        {
            Bullet bullet = Instantiate(_teamToBulletPrefab[team], _container);
            bullet.Initialize(position, direction, _levelBounds);
            return bullet;
        }
        
        public Bullet SpawnDefaultBullet(TeamType team)
        {
            Bullet bullet = Instantiate(_teamToBulletPrefab[team], _container);
            bullet.Initialize(_defaultPosition, _defaultDirection, _levelBounds);
            return bullet;
        }
    }
}