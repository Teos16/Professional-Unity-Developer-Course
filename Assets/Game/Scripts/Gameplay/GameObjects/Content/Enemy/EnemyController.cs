using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class EnemyController : NetworkBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;

        private Transform _target;
        
        public void SetTarget(Transform target) => _target = target;

        public override void FixedUpdateNetwork()
        {
            if (!HasStateAuthority || _target == null)
                return;

            Vector3 direction = _target.position - this.transform.position;
            direction.y = 0;
            _moveComponent.Move(direction.normalized);
        }
    }
}