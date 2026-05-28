// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class MoveTransformComponent : MonoBehaviour
//     {
//         [SerializeField]
//         private float _moveSpeed = 3f;
//
//         public void MoveStep(Vector3 moveDirection)
//         {
//             this.transform.position += moveDirection * _moveSpeed * Time.fixedDeltaTime;
//         }
//     }
// }