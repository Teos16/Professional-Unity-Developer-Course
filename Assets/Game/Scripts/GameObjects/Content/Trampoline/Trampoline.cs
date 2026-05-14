using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(TriggerComponent))]
    public sealed class Trampoline : MonoBehaviour
    {
        [SerializeField] private Vector2 _force;
        
        private TriggerComponent _triggerComponent;

        private void Awake() => _triggerComponent = GetComponent<TriggerComponent>();

        private void OnEnable() => _triggerComponent.OnEntered += OnEntered;

        private void OnDisable() => _triggerComponent.OnEntered -= OnEntered;

        private void OnEntered(Collider2D other)
        {
            if (other.TryGetComponent(out Rigidbody2D rigidbody))
            {
                rigidbody.linearVelocityY = 0;
                rigidbody.AddForce(_force, ForceMode2D.Impulse);
            }
        }
    }
}