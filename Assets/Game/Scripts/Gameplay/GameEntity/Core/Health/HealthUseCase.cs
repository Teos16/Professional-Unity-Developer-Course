using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class HealthUseCase
    {
        public static bool AddHealth(this IGameEntity entity, int healValue)
        {
            if (entity.IsDead()) 
                return false;
            
            IVariable<int> health = entity.GetValue(GameEntityAPI.Health);
            int maxHealth = entity.GetValue(GameEntityAPI.MaxHealth).Value;
            int newHealth = Mathf.Min(maxHealth, health.Value + healValue);
            health.Value = newHealth;
            return true;
        }
        
        public static bool ReduceHealth(this IGameEntity entity, int damage)
        {
            if (entity.IsDead()) 
                return false;
            
            IVariable<int> health = entity.GetValue(GameEntityAPI.Health);
            int newHealth = Mathf.Max(0, health.Value - damage);
            health.Value = newHealth;
            return true;
        }
        
        public static bool IsHealthAtMax(this IGameEntity entity)
        {
            int health = entity.GetValue(GameEntityAPI.Health).Value;
            int maxHealth = entity.GetValue(GameEntityAPI.MaxHealth).Value;
            return health == maxHealth;
        }

        public static bool IsAlive(this IGameEntity entity) => entity.GetValue(GameEntityAPI.Health).Value > 0;
        
        public static bool IsDead(this IGameEntity entity) => !entity.IsAlive();
    }
}