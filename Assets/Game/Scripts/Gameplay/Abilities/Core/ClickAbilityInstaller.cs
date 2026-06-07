using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [Serializable]
    public sealed class ClickAbilityInstaller
    {
        [SerializeField]
        private KeyCode _keyCode;
        
        public void Install(IAbilityEntity ability)
        {
            ability.AddClickRequest(new Request());
            ability.AddClickCommand(new Command());
            ability.WhenTick(_ =>
            {
                if (Input.GetKeyDown(_keyCode))
                    ability.GetClickRequest().Invoke();
            });
            ability.WhenFixedTick(_ =>
            {
                if (ability.GetClickRequest().Consume())
                    ability.GetClickCommand().Invoke();
            });
        }
    }
}