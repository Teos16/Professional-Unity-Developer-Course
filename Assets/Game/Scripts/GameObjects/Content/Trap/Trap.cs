using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CollisionComponent), typeof(HealthComponent))]
    public sealed class Trap : MonoBehaviour
    {
        [SerializeField] private float _damageToEnemy = 1;
        
        private CollisionComponent _collisionComponent;
        private HealthComponent _healthComponent;

        private void Awake()
        {
            _collisionComponent = GetComponent<CollisionComponent>();
            _healthComponent = GetComponent<HealthComponent>();
        }

        private void OnEnable()
        {
            _collisionComponent.OnEntered += OnCollision;
            _healthComponent.OnDied += OnDeath;
        }

        private void OnDisable()
        {
            _collisionComponent.OnEntered -= OnCollision;
            _healthComponent.OnDied -= OnDeath;
        }

        private void OnCollision(Collision2D obj)
        {
            if (!obj.gameObject.TryGetComponent(out HealthComponent healthComponent)) return;
            healthComponent.TakeDamage(_damageToEnemy);
            _healthComponent.SetZero();
        }

        private void OnDeath() => Destroy(gameObject);
    }
}