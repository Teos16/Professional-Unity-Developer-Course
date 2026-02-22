using UnityEngine;

namespace Game.Ships
{
    public sealed class StraightFireDirection : FireDirection
    {
        public override Vector3 GetBulletDirection() => _firePoint.up;
    }
}