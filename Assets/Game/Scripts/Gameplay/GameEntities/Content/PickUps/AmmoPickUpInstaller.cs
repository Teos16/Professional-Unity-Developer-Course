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

            entity.GetInteractCommand()
                .AddCondition(target => target.HasCharacterTag())
                .AddCondition(_ => _cooldown.IsCompleted())
                .AddAction(target =>
                {
                    if (target.CollectAmmoWithWeapon(_ammo))
                        _cooldown.ResetTime();
                });


            entity.WhenFixedTick(_cooldown.Tick);
            entity.WhenLateTick(_ => _visual.SetActive(_cooldown.IsCompleted())); //KISS
        }
    }
}