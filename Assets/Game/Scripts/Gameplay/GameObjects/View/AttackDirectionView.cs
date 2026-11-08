using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class AttackDirectionView : NetworkBehaviour
    {
        [SerializeField] private float _turnSpeed = 720;

        private RangeAttackComponent _rangeAttack;

        public override void Spawned() => _rangeAttack = Object.GetBehaviour<RangeAttackComponent>();

        public override void Render()
        {
            Vector3 direction = _rangeAttack.AttackDirection;
            direction.y = 0;
            if (direction == Vector3.zero)
                return;

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(direction), _turnSpeed * Time.deltaTime);
        }
    }
}
