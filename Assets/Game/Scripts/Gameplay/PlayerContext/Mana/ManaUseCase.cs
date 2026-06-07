using Atomic.Entities;

namespace Game.Gameplay
{
    public static class ManaUseCase
    {
        public static bool CanSpendMana(this IPlayerContext context, int amount) =>
            context.GetValue(PlayerContextAPI.Mana).Value - amount >= 0;

        public static void SpendMana(this IPlayerContext context, int amount) =>
            context.GetValue(PlayerContextAPI.Mana).Value -= amount;
    }
}