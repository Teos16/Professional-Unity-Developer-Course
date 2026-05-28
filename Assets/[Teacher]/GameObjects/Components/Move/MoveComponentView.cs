// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class MoveComponentView : MonoBehaviour
//     {
//         private static readonly int IsMoving = Animator.StringToHash("IsMoving");
//         
//         [SerializeField]
//         private Animator _animator;
//
//         private MoveRequestComponent _moveComponent;
//
//         private void Awake()
//         {
//             _moveComponent = this.GetComponentInParent<MoveRequestComponent>();
//         }
//
//         private void Update()
//         {
//             _animator.SetBool(IsMoving, _moveComponent.IsMoving);
//         }
//     }
// }