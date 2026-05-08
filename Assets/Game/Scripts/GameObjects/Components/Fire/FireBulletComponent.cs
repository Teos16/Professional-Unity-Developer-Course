using UnityEngine;

namespace SampleGame.Components
{
    public sealed class FireBulletComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        
        public void Fire() => 
            Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }
}