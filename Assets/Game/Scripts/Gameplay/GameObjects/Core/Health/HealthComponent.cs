using System;
using Fusion;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public sealed class HealthComponent : NetworkBehaviour
    {
        public event Action<int> OnHealthChanged;

        [SerializeField] private HealthConfig _config;

        [Networked, OnChangedRender(nameof(InvokeHealthChanged))]
        public int Current { get; set; }

        public int Max => _config.MaxHealth;

        public bool IsDead => Current <= 0;

        public bool IsAlive => Current > 0;

        public override void Spawned()
        {
            if (HasStateAuthority)
                Current = _config.MaxHealth;
        }

        [Button]
        public void TakeDamage(int damage)
        {
            if (damage <= 0 || IsDead)
                return;

            Current = Math.Max(0, Current - damage);
        }

        [Button]
        public void Die() => Current = 0;

        private void InvokeHealthChanged() => OnHealthChanged?.Invoke(Current);
    }
}
