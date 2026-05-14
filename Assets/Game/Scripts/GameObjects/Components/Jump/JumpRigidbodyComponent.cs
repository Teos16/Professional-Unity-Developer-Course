using UnityEngine;

namespace Game
{
    public sealed class JumpRigidbodyComponent : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 12f;
        
        private Rigidbody2D _rigidbody;
        
        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
        
        public void Jump() => _rigidbody?.AddForceY(_jumpForce, ForceMode2D.Impulse);
    }
}