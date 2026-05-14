using UnityEngine;

namespace Game
{
    public sealed class JumpAnimationComponent : MonoBehaviour
    {
        private static readonly int Jump = Animator.StringToHash("Jump");
        
        private Animator _animator;
        private JumpRequestComponent _jumpRequestComponent;

        private void Awake()
        {
            _jumpRequestComponent = GetComponentInParent<JumpRequestComponent>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void OnEnable() => _jumpRequestComponent.OnJumped += OnJump;
        
        private void OnDisable() => _jumpRequestComponent.OnJumped -= OnJump;
        
        private void OnJump() => _animator.SetTrigger(Jump);
    }
}