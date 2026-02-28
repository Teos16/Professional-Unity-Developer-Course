using System;
using UnityEngine;

namespace Game.Ships
{
    [RequireComponent(typeof(MoveComponent)), RequireComponent(typeof(HealthComponent)),
     RequireComponent(typeof(WeaponComponent))]
    public sealed class Ship : MonoBehaviour
    {
        //current and max health
        public event Action<int, int> OnHealthChanged
        {
            add => _health.OnHealthChanged += value;
            remove => _health.OnHealthChanged -= value;
        }
        
        public event Action<GameObject> OnDeath
        {
            add => _health.OnDeath += value;
            remove => _health.OnDeath -= value;
        }
        
        public event Action OnFired
        {
            add => _weapon.OnFired += value;
            remove => _weapon.OnFired -= value;
        }
        
        public Vector3 MoveDirection => _move.MoveDirection;

        [SerializeField] private ShipConfig _config;
        [SerializeField] private MoveComponent _move;
        [SerializeField] private HealthComponent _health;
        [SerializeField] private WeaponComponent _weapon;
        
        private void Awake()
        {
            _health.SetConfig(_config);
            _move.SetConfig(_config);
            _weapon.SetConfig(_config);

            _move.AddMoveCondition(IsAlive);
            _weapon.AddFireCondition(IsAlive);
            
            _health.Reset();
        }

        private void OnEnable() => _health.Reset();

        public void FireAt(Vector2 position) => _weapon.FireAt(position);
        
        public void FireUp() => _weapon.FireTowards(transform.up);

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            if (_health.CurrentHealth <= 0) 
                gameObject.SetActive(false);
        }

        public bool IsAlive() => _health.IsAlive();

        public void MoveStep(Vector2 direction) => _move.MoveStep(direction);
    }
}