using System;
using Game.Bullets;
using Game.Enemy;
using UnityEngine;

namespace Game.Ships
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public event Action OnFired;
        
        [SerializeField] private CooldownTimer _cooldownTimer;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private FireDirection _fireDirection;
        [SerializeField] private BulletConfig _usedBulletConfig;
        [SerializeField] private Pool _bulletPool;
        
        private CompositeCondition _fireConditions = new();

        public void Construct(Pool bulletPool) => _bulletPool = bulletPool;

        public void SetConfig(ShipConfig config) => 
            _cooldownTimer.SetCooldownLimits(config.FireCooldown, config.FireCooldown);

        public void AddFireCondition(Func<bool> condition)  => 
            _fireConditions.AddCondition(new SingleCondition(condition));

        public void Fire()
        {
            if (_cooldownTimer.IsReady() && _fireConditions.Evaluate())
            {
                GameObject bullet = _bulletPool.Rent();
                bullet.GetComponent<Bullet>().SetPosition(_firePoint.position);
                bullet.GetComponent<Bullet>().SetDirection(_fireDirection.GetBulletDirection());
                bullet.GetComponent<Bullet>().SetConfig(_usedBulletConfig);
                _cooldownTimer.Reset();
                bullet.SetActive(true);
                OnFired?.Invoke();
            }
        }
    }
}