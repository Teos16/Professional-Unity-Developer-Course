using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class TargetFinderComponent : NetworkBehaviour
    {
        public interface ICondition
        {
            bool IsMet();
        }

        private static readonly Collider[] s_colliders = new Collider[8];

        [SerializeField] private TargetFinderConfig _config;
        [SerializeField] private LayerMask _targetMask;

        private ICondition _condition;

        public void SetCondition(ICondition condition) => _condition = condition;

        public bool TryFindTarget(out Collider target)
        {
            target = null;
            if (_condition == null || !_condition.IsMet())
                return false;

            float minDistance = float.MaxValue;
            Vector3 origin = transform.position;

            int count = Runner.GetPhysicsScene().OverlapSphere(
                origin,
                _config.Radius,
                s_colliders,
                _targetMask,
                QueryTriggerInteraction.Ignore
            );

            for (int i = 0; i < count; i++)
            {
                Collider collider = s_colliders[i];
                NetworkObject other = collider.GetComponentInParent<NetworkObject>();
                if (other == null || !other.IsValid ||
                    !other.TryGetBehaviour(out HealthComponent health) || health.IsDead)
                    continue;

                float distance = (collider.bounds.center - origin).sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = collider;
                }
            }

            return target != null;
        }

        private void OnDrawGizmosSelected()
        {
            if (_config == null)
                return;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _config.Radius);
        }
    }
}
