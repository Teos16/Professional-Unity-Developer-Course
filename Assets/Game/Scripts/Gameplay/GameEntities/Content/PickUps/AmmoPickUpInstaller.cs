using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class AmmoPickUpInstaller : PickUpInstaller
    {
        [SerializeField]
        private int _ammo = 3;

        [SerializeField]
        private Cooldown _cooldown = 4;

        [SerializeField]
        private GameObject _visual; //KISS

        public override void Install(IGameEntity entity)
        {
            base.Install(entity);

            entity.GetInteractCondition().Add(target => target.HasCharacterTag());
            entity.GetInteractCondition().Add(_ => _cooldown.IsCompleted());
            
            entity.GetInteractAction().Add(target =>
            {
                if (target.CollectAmmoWithWeapon(_ammo)) 
                    _cooldown.ResetTime();
            });
            
            entity.WhenFixedTick(_cooldown.Tick);
            entity.WhenLateTick(_ => _visual.SetActive(_cooldown.IsCompleted())); //KISS
        }
    }
}