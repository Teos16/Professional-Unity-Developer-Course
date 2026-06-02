using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public static class HealthUseCase
    {
        public static void TakeDamageArmored(this IEntity entity, int damage, float armorPercent)
        {
            damage = Mathf.RoundToInt(damage * (1.0f - armorPercent));
            entity.TakeDamage(damage);
        }

        public static void TakeDamage(this IEntity entity, int damage)
        {
            if (entity.IsAlive())
            {
                IVariable<int> health = entity.GetHealth();
                health.Value = Mathf.Max(0, health.Value - damage);
            }
        }

        public static bool IsAlive(this IEntity entity)
        {
            return entity.GetHealth().Value > 0;
        }
    }
}