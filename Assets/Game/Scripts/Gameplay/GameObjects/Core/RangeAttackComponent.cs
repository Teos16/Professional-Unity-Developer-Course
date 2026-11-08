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
        
        [Networked] public int AttackCount { get; private set; }
        [Networked] public Vector3 AttackDirection { get; private set; }

        [SerializeField] private Transform _attackPoint;

        [Networked] private TickTimer _cooldownTimer { get; set; }

        private float _cooldown;
        private ProjectileWorld _projectileWorld;
        private ICondition _condition;

        public override void Spawned() => _projectileWorld = GetBehaviour<ProjectileWorld>();

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
            {
                _cooldownTimer = TickTimer.CreateFromSeconds(this.Runner, _cooldown);
                this.AttackDirection = direction;
                this.AttackCount++;
            }
        }
    }
}