namespace Game.Gameplay
{
    public static class FireUseCase
    {
        public static void Fire(this IWeaponEntity weapon)
        {
            if (weapon.GetFireCondition().Invoke())
            {
                weapon.GetFireAction().Invoke();
                weapon.GetFireEvent().Invoke();
            }
        }
    }
}