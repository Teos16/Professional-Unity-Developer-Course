using UnityEngine;

namespace Game
{
    public sealed class MoveAnimationComponent : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");


        private MoveRequestComponent _moveRequestComponent;
        private GroundedComponent _groundedComponent;
        private Animator _animator;

        private void Awake()
        {
            _moveRequestComponent = GetComponentInParent<MoveRequestComponent>();
            _groundedComponent = GetComponentInParent<GroundedComponent>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(IsMoving, _moveRequestComponent.IsMoving);  
        }

        private void OnEnable()
        {
            _groundedComponent.OnGrounded += OnGrounded;
        }
        
        private void OnDisable()
        {
            _groundedComponent.OnGrounded -= OnGrounded;
        }

        private void OnGrounded(bool b) => _animator.SetBool(IsGrounded, b);
    }
}