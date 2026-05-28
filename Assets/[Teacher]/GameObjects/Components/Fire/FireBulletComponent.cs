// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class FireBulletComponent : FireComponentBase
//     {
//         [SerializeField]
//         private GameObject _bulletPrefab;
//
//         [SerializeField]
//         private Transform _firePoint;
//         
//         public override void Fire()
//         {
//             Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
//         }
//     }
// }