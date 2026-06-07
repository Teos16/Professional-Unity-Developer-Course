using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WeaponPickUpInstaller : PickUpInstaller
    {
        [SerializeField]
        private WeaponEntity _weaponPrefab;

        [SerializeField]
        private Optional<Variable<int>> _ammo;

        [SerializeField]
        private Optional<ReactiveVariable<int>> _health;

        public override void Install(IGameEntity entity)
        {
            base.Install(entity);

            GameContext gameContext = GameContext.Instance;
            entity.GetInteractCommand()
                .AddCondition(target => target.HasCharacterTag())
                .AddAction(target => target.PickUpWeapon(entity, gameContext));
            
            entity.AddWeaponPrefab(_weaponPrefab);

            if (_ammo)
                entity.AddAmmo(_ammo.Value);

            if (_health) 
                entity.AddHealth(_health.Value);
        }
    }
}