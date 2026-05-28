using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public static class HealthUseCase
    {
        public static bool IsAlive(this IEntity entity) => entity.GetHealth().Value > 0;
        
        public static void TakeDamageArmored(this IEntity entity, int damage, float armorPercent)
        {
            damage = Mathf.RoundToInt(damage * (1.0f - armorPercent));
            entity.TakeDamage(damage);
        }
        
        public static void TakeDamage(this IEntity entity, int damage)
        {
            IVariable<int> health = entity.GetHealth();
            health.Value = Mathf.Max(0, health.Value - damage);
        }
    }
}