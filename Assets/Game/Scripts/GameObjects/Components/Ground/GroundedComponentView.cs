using UnityEngine;

namespace Game
{
    public sealed class GroundedComponentView : MonoBehaviour
    {
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int IsFalling = Animator.StringToHash("IsFalling");
        
        private Animator _animator;
        private GroundedComponent _groundedComponent;

        private void Awake()
        {
            _groundedComponent = GetComponentInParent<GroundedComponent>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void OnEnable() => _groundedComponent.OnGrounded += OnGrounded;

        private void OnDisable() => _groundedComponent.OnGrounded -= OnGrounded;

        private void OnGrounded(bool b)
        {
            _animator.SetBool(IsGrounded, b);
            _animator.SetBool(IsFalling, !_groundedComponent.IsGrounded);
        }
    }
}