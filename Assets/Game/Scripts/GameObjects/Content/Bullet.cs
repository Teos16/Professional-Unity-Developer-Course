using SampleGame.Components;
using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(MoveTransformComponent))]
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField]
        private int _damage = 2;

        [SerializeField]
        private float _lifetime = 5;
        
        private MoveTransformComponent _moveTransformComponent;

        private void Awake() => _moveTransformComponent = GetComponent<MoveTransformComponent>();

        private void Start() => Destroy(this.gameObject, _lifetime);

        private void FixedUpdate() => _moveTransformComponent.MoveStep(transform.forward);

        private void OnTriggerEnter(Collider other)
        {
            HealthComponent healthComponent = other.GetComponentInParent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(_damage);
                Destroy(this.gameObject);
            }
        }
    }
}