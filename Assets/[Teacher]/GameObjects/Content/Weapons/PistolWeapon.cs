// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class PistolWeapon : MonoBehaviour
//     {
//         private FireRequestComponent _fireRequestComponent;
//         private FireBulletComponent _fireBulletComponent;
//
//         private void Awake()
//         {
//             _fireRequestComponent = this.GetComponent<FireRequestComponent>();
//             _fireBulletComponent = this.GetComponent<FireBulletComponent>();
//             _fireRequestComponent.SetAction(_fireBulletComponent.Fire);
//         }
//     }
// }