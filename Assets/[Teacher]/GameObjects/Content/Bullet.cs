// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class Bullet : MonoBehaviour
//     {
//         [SerializeField]
//         private int _damage = 2;
//
//         [SerializeField]
//         private float _lifetime = 5;
//         
//         [SerializeField]
//         private MoveTransformComponent _moveComponent;
//         
//         private void Start()
//         {
//             Destroy(this.gameObject, _lifetime);
//         }
//
//         private void FixedUpdate()
//         {
//             _moveComponent.MoveStep(this.transform.forward);
//         }
//
//         private void OnTriggerEnter(Collider other)
//         {
//             HealthComponent damageable = other.GetComponentInParent<HealthComponent>();
//             if (damageable != null)
//             {
//                 damageable.TakeDamage(_damage);
//                 Destroy(this.gameObject);
//             }
//         }
//     }
// }