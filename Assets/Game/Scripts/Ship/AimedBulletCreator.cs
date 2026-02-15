using Game.Bullet;
using UnityEngine;

namespace Game.ShipRelated
{
    public sealed class AimedBulletCreator : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        
        private BulletPool _bulletPool;
        private Ship _target;

        private void OnEnable() => _ship.OnFired += OnFire;

        private void OnDisable() => _ship.OnFired -= OnFire;

        public void Initialize(BulletPool bulletPool, Ship target)
        {
            _bulletPool = bulletPool;
            _target = target;
        }

        private void OnFire()
        {
            Vector3 targetPosition = _target.transform.position;
            Vector3 direction = (targetPosition - _ship.firePoint.position).normalized;
            _bulletPool.Rent(_ship.firePoint.position, direction, _ship.Team);
        }
    }
}