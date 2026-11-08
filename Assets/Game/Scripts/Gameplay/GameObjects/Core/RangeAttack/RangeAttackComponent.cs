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

        [SerializeField] private RangeAttackConfig _config;
        [SerializeField] private Transform _attackPoint;

        [Networked] public int AttackCount { get; private set; }
        [Networked] public Vector3 AttackDirection { get; private set; }
        [Networked] private TickTimer _cooldownTimer { get; set; }

        private ProjectileWorld _projectileWorld;
        private ICondition _condition;

        public override void Spawned() => _projectileWorld = GetBehaviour<ProjectileWorld>();

        public void SetCondition(ICondition condition) => _condition = condition;

        public void Attack(Vector3 targetPoint)
        {
            if (_cooldownTimer.IsRunning(Runner))
                return;

            if (_condition == null || !_condition.IsMet())
                return;

            Vector3 direction = targetPoint - _attackPoint.position;
            if (direction == Vector3.zero)
                return;

            if (_projectileWorld.TrySpawn(_attackPoint.position, Quaternion.LookRotation(direction)))
            {
                _cooldownTimer = TickTimer.CreateFromSeconds(Runner, _config.Cooldown);
                AttackDirection = direction;
                AttackCount++;
            }
        }
    }
}
