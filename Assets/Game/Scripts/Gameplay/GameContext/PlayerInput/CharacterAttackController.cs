using Atomic.Elements;
using Atomic.Entities;
using Game.UI;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterAttackController : IGameContextInit, IGameContextTick
    {
        private readonly IVariable<Joystick> _joystick;
        private IGameEntity _player;
        
        public CharacterAttackController(IGameUI ui) => _joystick = ui.GetValue(GameUIAPI.AttackJoystick);

        public void Init(IGameContext entity) => _player = entity.GetValue(GameContextAPI.Player);

        public void Tick(IGameContext entity, float deltaTime)
        {
            if(_joystick.Value == null)
                return;
            
            Vector3 direction = new Vector3(_joystick.Value.Direction.x, 0, _joystick.Value. Direction.y);
            _player.GetValue(GameEntityAPI.AimDirection).Value = direction;
            if (direction == Vector3.zero) 
                return;
            
            _player.GetValue(GameEntityAPI.AttackRequest).Invoke();
        }
    }
}