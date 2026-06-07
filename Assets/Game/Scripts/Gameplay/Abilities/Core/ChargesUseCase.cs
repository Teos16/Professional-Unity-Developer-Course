using Game.Gameplay;

namespace SampleGame
{
    public static class ChargesUseCase
    {
        public static bool IsChargesExists(this IAbilityEntity ability) => ability.GetCharges().Value > 0;

        public static void SpendCharge(this IAbilityEntity ability) => ability.GetCharges().Value--;
    }
}