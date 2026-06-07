using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "StunAbility",
        menuName = "Game/Abilities/New StunAbility"
    )]
    public sealed class StunAbilityConfig : AbilityEntityConfig
    {
        [SerializeField]
        private StunEffectConfig _effect;

        [SerializeField]
        private float _cooldown;

        [SerializeField]
        private int _initialCharges;

        [SerializeField]
        private TargetAbilityInstaller _targetInstaller;

        protected override void Install(IAbilityEntity ability, IPlayerContext playerContext)
        {
            _targetInstaller.Install(ability, playerContext);
            ability.GetTargetCommand()
                .AddCondition(playerContext.IsEnemy)
                .AddCondition(_ => ability.GetCooldown().IsCompleted())
                .AddCondition(target => target.CanApplyEffect(_effect))
                .AddAction(_ => ability.GetCooldown().ResetTime())
                .AddAction(target => target.ApplyEffect(_effect));

            ability.AddCooldown(new Cooldown(_cooldown, 0));
            ability.WhenFixedTick(ability.GetCooldown().Tick);
        }
    }
}