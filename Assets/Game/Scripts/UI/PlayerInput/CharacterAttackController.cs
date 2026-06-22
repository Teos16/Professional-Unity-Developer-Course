using Atomic.Elements;
using Atomic.Entities;
using Game.UI;

namespace Game.Gameplay
{
    public sealed class CharacterAttackController : IGameUIInit, IGameUITick
    {
        private IVariable<Joystick> _joystick;
        private IGameEntity _player;
        
        public CharacterAttackController(GameContext gameContext) => _player = gameContext.GetValue(GameContextAPI.Player);

        public void Init(IGameUI ui) => _joystick = ui.GetValue(GameUIAPI.AttackJoystick);

        public void Tick(IGameUI ui, float deltaTime)
        {
            if(_joystick.Value == null)
                return;
            
            _player.AttackWithJoystick(_joystick.Value);
        }
    }
}