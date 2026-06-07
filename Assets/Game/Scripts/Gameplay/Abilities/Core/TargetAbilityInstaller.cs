using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class TargetAbilityInstaller
    {
        [SerializeField]
        private KeyCode _keyCode;
        
        public void Install(IAbilityEntity ability, IPlayerContext context)
        {
            ability.AddTargetRequest(new Request<IGameEntity>());
            ability.AddTargetCommand(new Command<IGameEntity>());
            ability.WhenTick(_ =>
            {
                if (Input.GetKey(_keyCode) && Input.GetMouseButtonDown(0) &&
                    context.RaycastTarget(Input.mousePosition, out IGameEntity point))
                    ability.GetTargetRequest().Invoke(point);
            });
            ability.WhenFixedTick(_ =>
            {
                if (ability.GetTargetRequest().Consume(out IGameEntity point))
                    ability.GetTargetCommand().Invoke(point);
            });
        }
    }
}