using System;
using Game.ShipRelated;
using Modules.Utils;
using UnityEngine;

namespace Game.BulletRelated
{
    public class Bullet : MonoBehaviour
    {
        public event Action OnHit;
        public event Action<TeamType> OnConfigChanged; 
        
        public TeamType Team => _config.TeamType;
        private Vector2 _direction;

        [SerializeField] private BulletConfig _config;

        private TransformBounds _levelBounds;
        private Pool _bulletPool;

        private void FixedUpdate()
        {
            Vector3 moveStep = _direction * (_config.BulletSpeed * Time.fixedDeltaTime);
            transform.position += moveStep;

            if (!_levelBounds.InBounds(transform.position))
            {
                _bulletPool.Return(gameObject);
                gameObject.SetActive(false);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnHit?.Invoke();
            if(other.TryGetComponent(out Ship ship))
                ship.TakeDamage(_config.BulletDamage);
            _bulletPool.Return(gameObject);
            gameObject.SetActive(false);
        }

        public void Construct(TransformBounds levelBounds) => _levelBounds ??= levelBounds;
        
        public void SetConfig(BulletConfig config)
        {
            _config = config;
            OnConfigChanged?.Invoke(Team);
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }

        public void SetPosition(Vector2 position) => transform.position = position;
    }
}