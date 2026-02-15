using System;
using UnityEngine;

namespace Game.ShipRelated
{
    public sealed class HealthComponent
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }

        private readonly ShipConfig _config; 
        
        public event Action<int> OnHealthChanged;
        public event Action OnDied;
        
        public HealthComponent(ShipConfig config) => _config = config;

        public void Reset()
        {
            CurrentHealth = _config.Health;
            MaxHealth = _config.Health;
        }
        
        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
                OnHealthChanged?.Invoke(CurrentHealth);

                if (CurrentHealth <= 0) 
                    OnDied?.Invoke();
            }
        }

        public bool IsAlive() => CurrentHealth > 0;


    }
}