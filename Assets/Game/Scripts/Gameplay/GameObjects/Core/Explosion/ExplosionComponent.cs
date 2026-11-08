using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class ExplosionComponent : NetworkBehaviour
    {
        private static readonly Collider[] s_colliders = new Collider[8];

        [SerializeField] private ExplosionConfig _config;
        [SerializeField] private LayerMask _layerMask;

        public bool TryExplode()
        {
            int count = Runner.GetPhysicsScene().OverlapSphere(
                transform.position,
                _config.Radius,
                s_colliders,
                _layerMask,
                QueryTriggerInteraction.Ignore
            );

            bool exploded = false;
            for (int i = 0; i < count; i++)
            {
                NetworkObject other = s_colliders[i].GetComponentInParent<NetworkObject>();
                if (other != null &&
                    other.IsValid &&
                    other.TryGetBehaviour(out HealthComponent health) &&
                    health.IsAlive)
                {
                    health.TakeDamage(_config.Damage);
                    exploded = true;
                }
            }

            return exploded;
        }

        private void OnDrawGizmosSelected()
        {
            if (_config == null)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _config.Radius);
        }
    }
}
