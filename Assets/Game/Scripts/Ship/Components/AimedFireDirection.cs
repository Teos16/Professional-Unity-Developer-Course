using UnityEngine;

namespace Game.ShipRelated
{
    public sealed class AimedFireDirection : FireDirection
    {
        [SerializeField] private Ship _target;

        public override Vector3 GetBulletDirection() => (_target.transform.position - _firePoint.position).normalized;
    }
}