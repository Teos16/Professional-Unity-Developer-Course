using System;
using System.Collections.Generic;
using Game.BulletRelated;
using Game.Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.ShipRelated
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public event Action OnFired;
        
        [SerializeField] private CooldownTimer _cooldownTimer;
        [SerializeField] private Pool _bulletPool;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private FireDirection _fireDirection;
        [SerializeField] private BulletConfig _usedBulletConfig;

        private CompositeCondition _fireConditions = new();
        private ShipConfig _config;

        public void SetConfig(ShipConfig config) => 
            _cooldownTimer.SetCooldownLimits(config.FireCooldown, config.FireCooldown);

        public void AddFireCondition(Func<bool> condition)  => 
            _fireConditions.AddCondition(new SingleCondition(condition));

        public void Fire()
        {
            if (_cooldownTimer.IsReady() && _fireConditions.Evaluate())
            {
                GameObject bullet = _bulletPool.Rent();
                bullet.GetComponent<BulletRelated.Bullet>().SetPosition(_firePoint.position);
                bullet.GetComponent<BulletRelated.Bullet>().SetDirection(_fireDirection.GetBulletDirection());
                bullet.GetComponent<BulletRelated.Bullet>().SetConfig(_usedBulletConfig);
                OnFired?.Invoke();
            }
        }
    }
}