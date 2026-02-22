using System;
using Game.Ships;
using Modules.Utils;
using UnityEngine;

namespace Game.Bullets
{
    public class Bullet : MonoBehaviour
    {
        private const string PLAYER_BULLET_LAYER = "PlayerBullet";
        private const string ENEMY_BULLET_LAYER = "EnemyBullet";
        
        public event Action OnHit;
        public event Action<TeamType> OnConfigChanged;

        [SerializeField] private BulletConfig _config;

        private TransformBounds _levelBounds;
        private Vector2 _direction;

        private void FixedUpdate()
        {
            Vector3 moveStep = _direction * (_config.BulletSpeed * Time.fixedDeltaTime);
            transform.position += moveStep;

            if (!_levelBounds.InBounds(transform.position)) 
                gameObject.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnHit?.Invoke();
            if(other.TryGetComponent(out Ship ship))
                ship.TakeDamage(_config.BulletDamage);
            gameObject.SetActive(false);
        }

        public void Construct(TransformBounds levelBounds) => _levelBounds = levelBounds;

        public void SetConfig(BulletConfig config)
        {
            _config = config;
            SetupCollisionLayer();
            OnConfigChanged?.Invoke(_config.TeamType);
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }

        public void SetPosition(Vector2 position) => transform.position = position;

        private void SetupCollisionLayer()
        {
            gameObject.layer = _config.TeamType switch
            {
                TeamType.Player => LayerMask.NameToLayer(PLAYER_BULLET_LAYER),
                TeamType.Enemy => LayerMask.NameToLayer(ENEMY_BULLET_LAYER),
                _ => gameObject.layer
            };
        }
    }
}