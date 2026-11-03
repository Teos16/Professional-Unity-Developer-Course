using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Portal : NetworkBehaviour
    {
        private static readonly Collider[] s_colliders = new Collider[5];
        
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private GameState _gameState;
        [SerializeField] private HealthComponent _portalHealth;

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
                    other.TryGetBehaviour(out Enemy enemy) &&
                    enemy.IsValid &&
                    other.TryGetBehaviour(out HealthComponent enemyHealth) &&
                    enemyHealth.IsAlive)
                {
                    enemyHealth.Die();
                    if(_portalHealth.IsAlive) 
                        _portalHealth.TakeDamage(1);
                    if (_portalHealth.IsDead)
                        _gameState.Status = GameStatus.Lost;
                }
            }
        }
    }
}