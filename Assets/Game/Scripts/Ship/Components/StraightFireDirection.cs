using UnityEngine;

namespace Game.ShipRelated
{
    public sealed class StraightFireDirection : FireDirection
    {
        public override Vector3 GetBulletDirection() => _firePoint.up;
    }
}