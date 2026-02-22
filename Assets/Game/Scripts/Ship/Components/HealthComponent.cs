using System;
using UnityEngine;

namespace Game.Ships
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth => _config.Health;

        private ShipConfig _config; 
        
        public event Action<int, int> OnHealthChanged;
        public event Action<GameObject> OnDeath;
        
        public void SetConfig(ShipConfig config) => _config = config;

        public void Reset() => CurrentHealth = _config.Health;

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
                OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);

                if (CurrentHealth <= 0) 
                    OnDeath?.Invoke(gameObject);
            }
        }

        public bool IsAlive() => CurrentHealth > 0;


    }
}