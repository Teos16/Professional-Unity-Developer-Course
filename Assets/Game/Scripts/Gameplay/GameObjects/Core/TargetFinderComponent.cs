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

        [SerializeField] private LayerMask _targetMask;
        
        private float _radius;
        private ICondition _condition;
        
        public void Initialize(float radius) => _radius = radius;

        public void SetCondition(ICondition condition) => _condition = condition;

        public bool TryFindTarget(out Collider target)
        {
            if (_condition == null || !_condition.IsMet())
            {
                target = null;
                return false;
            }
            
            target = null;
            float minDistance = float.MaxValue;
            Vector3 origin = this.transform.position;

            int count = this.Runner.GetPhysicsScene().OverlapSphere(
                origin,
                _radius,
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
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(this.transform.position, _radius);
        }
    }
}