using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class RangeAttackComponent : NetworkBehaviour
    {
        public interface ICondition
        {
            bool IsMet();
        }

        [SerializeField] private Transform _attackPoint;
        [SerializeField] private ProjectileWorld _projectileWorld;

        [Networked] private TickTimer _cooldownTimer { get; set; }
        
        private float _cooldown = 1;
        private ICondition _condition;
        
        public void Initialize(float cooldown) => _cooldown = cooldown;
        
        public void SetCondition(ICondition condition) => _condition = condition;

        public void Attack(Vector3 targetPoint)
        {
            if (_cooldownTimer.IsRunning(this.Runner))
                return;
            
            if (_condition == null || !_condition.IsMet())
                return;
            
            Vector3 direction = targetPoint - _attackPoint.position;
            if (direction == Vector3.zero)
                return;
            
            if (_projectileWorld.TrySpawn(_attackPoint.position, Quaternion.LookRotation(direction))) 
                _cooldownTimer = TickTimer.CreateFromSeconds(this.Runner, _cooldown);
        }
    }
}