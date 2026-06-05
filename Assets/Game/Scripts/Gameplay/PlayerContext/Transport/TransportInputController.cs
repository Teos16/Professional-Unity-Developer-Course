using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TransportInputController : IPlayerContextInit, IPlayerContextTick
    {
        private IGameContext _gameContext;
        private IGameEntity _character;
        private InputMap _inputMap;
        
        public TransportInputController(IGameContext gameContext)
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
            if (!_gameContext.IsPlaying())
                return;
            
            IGameEntity transport = _character.GetCurrentTransport().Value;
            if (transport == null)
                return;

            this.ProcessMove(transport);
            this.ProcessDrop();
        }
        
        private void ProcessMove(IGameEntity transport)
        {
            Vector3 direction = _inputMap.GetMoveDirection();
            transport.GetMoveRequest().Invoke(direction);
        }

        private void ProcessDrop()
        {
            if (_inputMap.IsDropPressed()) 
                _character.ExitTransport();
        }
    }
}