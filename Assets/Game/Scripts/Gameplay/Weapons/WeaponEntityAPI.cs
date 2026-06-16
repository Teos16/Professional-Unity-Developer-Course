using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public static class WeaponEntityAPI
    {
        // FIRE
        public static ValueKey<IWeaponEntity, ICommand> AttackCommand = new(nameof(AttackCommand));
        public static ValueKey<IWeaponEntity, ICooldown> AttackCooldown = new(nameof(AttackCooldown));

        // PROPERTIES
        public static ValueKey<IWeaponEntity, IValue<int>> Damage = new(nameof(Damage));
        public static ValueKey<IWeaponEntity, IReactiveVariable<int>> Ammo = new(nameof(Ammo));
        
        // MISC
        public static ValueKey<IWeaponEntity, IGameEntity> Owner = new(nameof(Owner));
        public static ValueKey<IWeaponEntity, IValue<float>> AttackDistance = new(nameof(AttackDistance));
    }
}