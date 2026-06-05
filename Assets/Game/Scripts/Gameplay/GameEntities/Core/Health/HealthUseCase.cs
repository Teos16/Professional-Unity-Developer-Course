using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public static class HealthUseCase
    {
        public static bool ReduceHealthWithArmor(this IGameEntity entity, int damage, float armorPercent)
        {
            damage = Mathf.RoundToInt(damage * (1.0f - armorPercent));
            return entity.ReduceHealth(damage);
        }

        public static float GetHealthPercent(this IGameEntity entity) => 
            (float) entity.GetHealth().Value / entity.GetMaxHealth().Value;

        public static bool ReduceHealth(this IGameEntity entity, int damage)
        {
            if (!entity.DoesHealthExist()) 
                return false;
            
            IVariable<int> health = entity.GetHealth();
            int newHealth = Mathf.Max(0, health.Value - damage);
            health.Value = newHealth;
            
            if (newHealth == 0) 
                entity.GetDeathEvent().Invoke();
            
            return true;
        }

        public static void SetMaxHealth(this IGameEntity entity) => 
            entity.GetHealth().Value = entity.GetMaxHealth().Value;

        public static bool DoesHealthExist(this IGameEntity entity) => entity.GetHealth().Value > 0;
        public static bool IsDead(this IGameEntity entity) => entity.GetHealth().Value <= 0;
    }
}