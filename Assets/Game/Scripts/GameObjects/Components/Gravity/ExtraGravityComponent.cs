using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(GroundedComponent), typeof(Rigidbody2D))]
    public sealed class ExtraGravityComponent : MonoBehaviour
    {
        public bool IsFalling => !_groundedComponent.IsGrounded && _rigidbody.linearVelocity.y <= 0;
        
        [SerializeField] private float _gravity = -7f;

        private GroundedComponent _groundedComponent;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _groundedComponent = GetComponent<GroundedComponent>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (IsFalling)
                _rigidbody.linearVelocity += new Vector2(0, _gravity * Time.fixedDeltaTime);
        }
    }
    
    public sealed class FallingAnimationComponent : MonoBehaviour
    {
        private static readonly int IsFalling = Animator.StringToHash("IsFalling");
        
        private Animator _animator;
        private ExtraGravityComponent _extraGravityComponent;

        private void Awake()
        {
            _extraGravityComponent = GetComponent<ExtraGravityComponent>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void Update() => _animator.SetBool(IsFalling, _extraGravityComponent.IsFalling);
    }
}