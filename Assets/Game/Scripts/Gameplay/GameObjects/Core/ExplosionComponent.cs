using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class ExplosionComponent : NetworkBehaviour
    {
        private static readonly Collider[] s_colliders = new Collider[8];

        [SerializeField] private LayerMask _layerMask;

        private float _radius;
        private int _damage;

        public void Initialize(float radius, int damage)
        {
            _radius = radius;
            _damage = damage;
        }

        public bool TryExplode()
        {
            int count = this.Runner.GetPhysicsScene().OverlapSphere(
                this.transform.position,
                _radius,
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
                    health.TakeDamage(_damage);
                    exploded = true;
                }
            }

            return exploded;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, _radius);
        }
    }
}