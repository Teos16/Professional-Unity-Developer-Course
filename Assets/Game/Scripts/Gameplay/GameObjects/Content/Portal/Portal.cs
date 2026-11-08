using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Portal : NetworkBehaviour
    {
        private static readonly Collider[] s_colliders = new Collider[8];

        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        private HealthComponent _health;

        public override void Spawned() => _health = GetBehaviour<HealthComponent>();

        public override void FixedUpdateNetwork()
        {
            int count = Runner.GetPhysicsScene().OverlapSphere(
                transform.position,
                _radius,
                s_colliders,
                _layerMask,
                QueryTriggerInteraction.Ignore
            );

            for (int i = 0; i < count; i++)
            {
                NetworkObject other = s_colliders[i].GetComponentInParent<NetworkObject>();
                if (other != null &&
                    other.IsValid &&
                    other.TryGetBehaviour(out Enemy _) &&
                    other.TryGetBehaviour(out HealthComponent enemyHealth) &&
                    enemyHealth.IsAlive)
                {
                    Runner.Despawn(other);
                    if (_health.IsAlive)
                        _health.TakeDamage(1);
                }
            }
        }
    }
}
