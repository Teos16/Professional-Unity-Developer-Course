using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class EnemyController : NetworkBehaviour
    {
        private MoveComponent _moveComponent;
        private MeleeAttackComponent _meleeAttackComponent;

        private Transform _target;

        public override void Spawned()
        {
            _moveComponent = GetBehaviour<MoveComponent>();
            _meleeAttackComponent = GetBehaviour<MeleeAttackComponent>();
        }

        public void SetTarget(Transform target) => _target = target;

        public override void FixedUpdateNetwork()
        {
            if (!HasStateAuthority || _target == null)
                return;

            Vector3 direction = _target.position - transform.position;
            direction.y = 0;
            _moveComponent.Move(direction.normalized);
            _meleeAttackComponent.Attack();
        }
    }
}
