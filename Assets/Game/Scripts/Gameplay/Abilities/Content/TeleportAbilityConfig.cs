using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "TeleportAbility",
        menuName = "Game/Abilities/New TeleportAbility"
    )]
    public sealed class TeleportAbilityConfig : AbilityEntityConfig
    {
        [SerializeField]
        private Const<float> _maxDistance;

        [SerializeField]
        private Const<int> _manaCost;

        [SerializeField]
        private PointAbilityInstaller _pointInstaller;

        protected override void Install(IAbilityEntity ability, IPlayerContext playerContext)
        {
            _pointInstaller.Install(ability, playerContext);
            ability.GetPointCommand()
                .AddCondition(_ => playerContext.CanSpendMana(_manaCost))
                .AddCondition(point =>
                    playerContext.GetValue(PlayerContextAPI.Character).LessOrEqualsDistance(point, _maxDistance))
                .AddAction(_ => playerContext.SpendMana(_manaCost))
                .AddAction(point => playerContext.GetValue(PlayerContextAPI.Character).Teleport(point));
        }
    }
}