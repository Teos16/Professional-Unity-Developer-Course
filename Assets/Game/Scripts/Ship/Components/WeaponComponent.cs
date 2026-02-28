using System;
using Game.Bullets;
using Game.Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Ships
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public event Action OnFired;
        
        [SerializeField] private CooldownTimer _cooldownTimer;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private BulletPool _bulletPool;
        
        private CompositeCondition _fireConditions = new();

        public void Construct(BulletPool bulletPool) => _bulletPool = bulletPool;

        public void SetConfig(ShipConfig config) => 
            _cooldownTimer.SetCooldownLimits(config.FireCooldown, config.FireCooldown);

        public void AddFireCondition(Func<bool> condition)  => 
            _fireConditions.AddCondition(new InlineCondition(condition));

        public void FireTowards(Vector2 direction)
        {
            if (_cooldownTimer.IsReady() && _fireConditions.Evaluate())
            {
                Bullet bullet = InitializeBullet();
                bullet.SetDirection(direction);
            }
        }
        
        public void FireAt(Vector2 position)
        {
            if (_cooldownTimer.IsReady() && _fireConditions.Evaluate())
            {
                Bullet bullet = InitializeBullet();
                bullet.SetDirection((position - (Vector2)_firePoint.position).normalized);
            }
        }

        private Bullet InitializeBullet()
        {
            Bullet bullet = _bulletPool.Rent();
            bullet.SetPosition(_firePoint.position);
            bullet.SetConfig(_bulletConfig);
            _cooldownTimer.Reset();
            OnFired?.Invoke();
            return bullet;
        }
    }
}