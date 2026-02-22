using UnityEngine;

namespace Game.Ships
{
    public abstract class FireDirection : MonoBehaviour
    {
        [SerializeField] protected Transform _firePoint;
        
        public abstract Vector3 GetBulletDirection();
    }
}