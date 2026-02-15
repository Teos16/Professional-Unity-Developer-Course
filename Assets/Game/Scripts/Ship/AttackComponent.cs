using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ShipRelated
{
    public sealed class AttackComponent
    {
        private HashSet<Func<bool>> _fireConditions = new();

        private float _fireCooldown;
        private float _fireTime;

        public AttackComponent(ShipConfig config)
        {
            _fireCooldown = config.FireCooldown;
            _fireConditions.Add(IsReadyToFire());
            _fireTime = Time.fixedTime;
        }

        public void AddFireCondition(Func<bool> condition) => _fireConditions.Add(condition);

        public bool Fire()
        {
            if (CanFire())
            {
                _fireTime = Time.fixedTime;
                return true;
            }
            return false;
        }

        private bool CanFire()
        {
            if(_fireConditions.Count == 0) 
                return true;
            
            foreach (Func<bool> condition in _fireConditions)
            {
                if (!condition.Invoke()) 
                    return false;
            }
            return true;
        }

        // cooldown stays here since there is no reason for such a small component for now
        private Func<bool> IsReadyToFire() => () => Time.fixedTime - _fireTime >= _fireCooldown;
    }
}