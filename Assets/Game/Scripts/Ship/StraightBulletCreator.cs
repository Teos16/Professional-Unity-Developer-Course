using Game.Bullet;
using UnityEngine;

namespace Game.ShipRelated
{
    public sealed class StraightBulletCreator : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private BulletPool _bulletPool;
        
        private void OnEnable() => _ship.OnFired += OnFired;

        private void OnDisable() => _ship.OnFired -= OnFired;

        private void OnFired() => _bulletPool.Rent(
            _ship.firePoint.position, _ship.firePoint.up, _ship.Team);
    }
}