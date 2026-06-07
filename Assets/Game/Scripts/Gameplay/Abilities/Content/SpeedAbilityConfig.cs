using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "SpeedAbility",
        menuName = "Game/Abilities/New SpeedAbility"
    )]
    public sealed class SpeedAbilityConfig : AbilityEntityConfig
    {
        [SerializeField]
        private Const<int> _initialCharges;

        [SerializeField]
        private MoveSpeedEffectConfig _effect;

        [SerializeField]
        private ClickAbilityInstaller _clickInstaller;

        protected override void Install(IAbilityEntity ability, IPlayerContext playerContext)
        {
            _clickInstaller.Install(ability);
            ability.GetClickCommand()
                .AddCondition(ability.IsChargesExists)
                .AddCondition(() => playerContext.GetValue(PlayerContextAPI.Character).CanApplyEffect(_effect))
                .AddAction(ability.SpendCharge)
                .AddAction(() => playerContext.GetValue(PlayerContextAPI.Character).ApplyEffect(_effect));

            ability.AddCharges(new ReactiveInt(_initialCharges));
        }
    }
}