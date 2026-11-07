using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Portal : NetworkBehaviour
    {
        private static readonly Collider[] s_colliders = new Collider[5];

        [SerializeField] private int _maxHealth = 10;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        private HealthComponent _portalHealth;

        public override void Spawned()
        {
            _portalHealth = GetBehaviour<HealthComponent>();
            _portalHealth.Initialize(_maxHealth);
        }

        public override void FixedUpdateNetwork()
        {
            int count = this.Runner.GetPhysicsScene().OverlapSphere(
                this.transform.position,
                _radius,
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
                    other.TryGetBehaviour(out Enemy enemy) &&
                    other.TryGetBehaviour(out HealthComponent enemyHealth) &&
                    enemyHealth.IsAlive)
                {
                    Runner.Despawn(other);
                    if(_portalHealth.IsAlive) 
                        _portalHealth.TakeDamage(1);
                }
            }
        }
    }
}