using System;
using Fusion;
using Sirenix.OdinInspector;

namespace Game
{
    public sealed class HealthComponent : NetworkBehaviour
    {
        public event Action<int> OnHealthChanged;
        
        [Networked, OnChangedRender(nameof(InvokeHealthChanged))] 
        public int Current { get; set; } = 10;
    
        public int Max { get; set; } = 10;

        public bool IsDead => this.Current <= 0;
    
        public bool IsAlive => this.Current > 0;
        
        public void Initialize(int maxHealth)
        {
            Max = maxHealth;
            if (HasStateAuthority)
                Current = maxHealth;
        }
        
        [Button]
        public void TakeDamage(int damage)
        {
            if (damage <= 0 || this.IsDead)
                return;

            this.Current = Math.Max(0, this.Current - damage);
        }
        
        [Button]
        public void Die()
        {
            this.Current = 0;
        }
        
        private void InvokeHealthChanged() => OnHealthChanged?.Invoke(Current);
    }
}