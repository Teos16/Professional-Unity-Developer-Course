using System;
using UnityEngine;

namespace Game.ShipRelated
{
    [RequireComponent(typeof(MoveComponent))]
    public sealed class Ship : MonoBehaviour
    {
        [field:SerializeField] public Transform firePoint { get; private set; }

        [field: SerializeField] public TeamType Team { get; private set; }
        
        public Vector3 MoveDirection => _move.MoveDirection;
        public float MoveSpeed => _move.MoveSpeed;

        [SerializeField] private ShipConfig _config;
        [SerializeField] private MoveComponent _move;
        
        private HealthComponent _health;
        private AttackComponent _attack;

        public event Action<int, int> OnHealthChanged; //current and max health
        public event Action OnDeath;
        public event Action OnFired;
        public event Action OnInitialized;

        private void Awake()
        {
            _health = new HealthComponent(_config);
            _attack = new AttackComponent(_config);
            
            _move.Initialize(_config);
            
            _attack.AddFireCondition(() => _health.IsAlive());
            _move.AddMoveCondition(() => _health.IsAlive());
            
            OnInitialized?.Invoke();
        }

        private void OnEnable() => _health.Reset();

        public void Fire()
        { 
            if(_attack.Fire())
                OnFired?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            OnHealthChanged?.Invoke(_health.CurrentHealth, _health.MaxHealth);
            if (_health.CurrentHealth <= 0)
            {
                OnDeath?.Invoke();
                gameObject.SetActive(false);
            }
        }

        public bool IsAlive() => _health.IsAlive();

        public void MoveStep(Vector2 direction) => _move.MoveStep(direction);
    }
}