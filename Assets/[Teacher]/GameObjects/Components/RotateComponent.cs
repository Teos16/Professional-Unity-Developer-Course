// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class RotateComponent : MonoBehaviour
//     {
//         [SerializeField]
//         private float _rotationSpeed = 360f;
//
//         public void RotateTowards(Transform target)
//         {
//             Vector3 direction = target.position - this.transform.position;
//             direction.y = 0;
//             this.RotateTowards(direction.normalized);
//         }
//         
//         public void RotateTowards(Vector3 direction)
//         {
//             Quaternion current = this.transform.rotation;
//             Quaternion target = Quaternion.LookRotation(direction, Vector3.up);
//             Quaternion next = Quaternion.RotateTowards(current, target, _rotationSpeed * Time.fixedDeltaTime);
//             this.transform.rotation = next;
//         }
//     }
// }