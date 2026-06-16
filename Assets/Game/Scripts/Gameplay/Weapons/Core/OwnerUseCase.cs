using Atomic.Entities;

namespace Game.Gameplay
{
    public static class OwnerUseCase
    {
        public static bool IsTargetCloseToOwner(this IWeaponEntity weapon)
        {
            IGameEntity owner = weapon.GetValue(WeaponEntityAPI.Owner);
            float attackDistance = weapon.GetValue(WeaponEntityAPI.AttackDistance).Value;
            return owner.IsTargetClose(attackDistance);
        }
    }
}