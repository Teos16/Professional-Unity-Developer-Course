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

        [SerializeField] private MeleeAttackConfig _config;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _layerMask;

        [Networked] private TickTimer _timestamp { get; set; }

        private ICondition _condition;

        public void SetCondition(ICondition condition) => _condition = condition;

        public void Attack()
        {
            if (_timestamp.IsRunning(Runner))
                return;

            if (_condition == null || !_condition.IsMet())
                return;

            int count = Runner.GetPhysicsScene().OverlapSphere(
                _attackPoint.position,
                _config.Radius,
                s_colliders,
                _layerMask,
                QueryTriggerInteraction.Ignore
            );

            for (int i = 0; i < count; i++)
            {
                NetworkObject other = s_colliders[i].GetComponentInParent<NetworkObject>();
                if (other != null &&
                    other.IsValid &&
                    other.TryGetBehaviour(out HealthComponent health) &&
                    health.IsAlive)
                {
                    health.TakeDamage(_config.Damage);
                    _timestamp = TickTimer.CreateFromSeconds(Runner, _config.Cooldown);
                    break;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (_attackPoint != null && _config != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(_attackPoint.position, _config.Radius);
            }
        }
    }
}
