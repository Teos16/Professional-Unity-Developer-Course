using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterInputController : IPlayerContextInit, IPlayerContextTick
    {
        private readonly IGameContext _gameContext;
        private IGameEntity _character;
        private InputMap _inputMap;

        public CharacterInputController(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void Init(IPlayerContext context)
        {
            _character = context.GetValue(PlayerContextAPI.Character);
            _inputMap = context.GetValue(PlayerContextAPI.InputMap);
        }

        public void Tick(IPlayerContext context, float deltaTime)
        {
            if (_gameContext.IsPlaying())
            {
                this.ProcessMove();
                this.ProcessInteract();
                this.ProcessFire();
                this.ProcessDrop();
            }
        }

        private void ProcessMove()
        {
            Vector3 direction = _inputMap.GetMoveDirection();
            _character.GetMoveRequest().Invoke(direction);
        }

        private void ProcessInteract()
        {
            if (_inputMap.IsInteractPressed())
                _character.InteractWith(_character.GetTargetInteractible().Value);
        }

        private void ProcessFire()
        {
            if (_inputMap.IsFirePressed())
                _character.GetFireRequest().Invoke();
        }

        private void ProcessDrop()
        {
            if (_inputMap.IsDropPressed() && _character.GetCurrentTransport().Value == null)
                _character.DropWeapon(_gameContext);
        }
    }
}