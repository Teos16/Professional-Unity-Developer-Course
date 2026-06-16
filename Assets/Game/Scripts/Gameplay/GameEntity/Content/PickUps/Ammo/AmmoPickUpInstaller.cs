using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class AmmoPickUpInstaller : PickUpInstaller
    {
        [BoxGroup("SPECIFIC"), SerializeField] private int _ammo = 10;

        public override void Install(IGameEntity entity)
        {
            base.Install(entity);

            entity.GetValue(GameEntityAPI.InteractCommand)
                .AddCondition(target => target.HasTag(GameEntityAPI.PlayerTag))
                .AddCondition(target => target.IsAlive())
                .AddCondition(target => target.HaveWeaponWithAmmo())
                .AddAction(target => target.CollectAmmoWithWeapon(_ammo))
                .AddAction(_ => entity.DelTag(GameEntityAPI.InteractableTag));
        }
    }
}