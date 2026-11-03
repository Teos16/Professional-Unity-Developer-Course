using System;
using Fusion;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public sealed class HealthComponent : NetworkBehaviour
    {
        [Networked]
        public int Current { get; set; } = 5;
    
        [field: SerializeField]
        public int Max { get; set; } = 10;

        public bool IsDead => this.Current <= 0;
    
        public bool IsAlive => this.Current > 0;

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
            Runner.Despawn(Object);
        }
    }
}