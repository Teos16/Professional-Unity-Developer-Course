using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class AmmoPickUpInstaller : PickUpInstaller
    {
        [SerializeField] private int _ammo = 3;

        public override void Install(IEntity entity)
        {
            base.Install(entity);
            entity.GetInteractCondition().Add(target => target.HasCharacterTag());
            entity.GetInteractAction().Add(target =>
            {
                if (target.CollectAmmo(_ammo))
                    Destroy(gameObject);
            });
        }
    }
}