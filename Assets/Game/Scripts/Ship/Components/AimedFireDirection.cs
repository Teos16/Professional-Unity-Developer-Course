using UnityEngine;

namespace Game.Ships
{
    public sealed class AimedFireDirection : FireDirection
    {
        private Ship _target;
        
        public void Construct(Ship target) => _target = target;

        public override Vector3 GetBulletDirection() => (_target.transform.position - _firePoint.position).normalized;
    }
}