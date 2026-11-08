using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class MeleeAttackComponent : NetworkBehaviour
    {
        public interface ICondition
        {
            bool IsMet();
        }

        private static readonly Collider[] s_colliders = new Collider[8];

        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _layerMask;
        
        [Networked] private TickTimer _timestamp { get; set; }

        private float _attackRadius;
        private float _cooldown;
        private int _damage;

        private ICondition _condition;

        public void Initialize(float radius, float cooldown, int damage)
        {
            _attackRadius = radius;
            _damage = damage;
            _cooldown = cooldown;
        }

        public void SetCondition(ICondition condition) => _condition = condition;

        public void Attack()
        {
            if (_timestamp.IsRunning(this.Runner))
                return;

            if (_condition == null || !_condition.IsMet())
                return;

            int count = this.Runner.GetPhysicsScene().OverlapSphere(
                _attackPoint.position,
                _attackRadius,
                s_colliders,
                _layerMask,
                QueryTriggerInteraction.Ignore
            );

            for (int i = 0; i < count; i++)
            {
                Collider _collider = s_colliders[i];
                NetworkObject other = _collider.GetComponentInParent<NetworkObject>();
                if (other != null &&
                    other.IsValid &&
                    other.TryGetBehaviour(out HealthComponent health) &&
                    health.IsAlive)
                {
                    health.TakeDamage(_damage);
                    _timestamp = TickTimer.CreateFromSeconds(this.Runner, _cooldown);
                    break;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (_attackPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
            }
        }
    }
}