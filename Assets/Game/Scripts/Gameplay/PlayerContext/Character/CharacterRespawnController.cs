using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterRespawnController : IPlayerContextInit, IPlayerContextFixedTick, IPlayerContextDispose
    {
        private readonly IGameContext _gameContext;

        private ICooldown _cooldown;
        private IGameEntity _character;
        private Subscription<int> _subscription;
        
        public CharacterRespawnController(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void Init(IPlayerContext context)
        {
            _character = context.GetValue(PlayerContextAPI.Character);
            _cooldown = context.GetValue(PlayerContextAPI.RespawnCooldown);
            _subscription = _character.GetHealth().Subscribe(this.OnHealthChanged);
        }

        public void Dispose(IPlayerContext entity)
        {
            _subscription.Dispose();
        }

        private void OnHealthChanged(int health)
        {
            if (health <= 0) 
                _cooldown.ResetTime();
        }

        public void FixedTick(IPlayerContext entity, float deltaTime)
        {
            if (_cooldown.IsCompleted())
                return;

            _cooldown.Tick(deltaTime);
            if (_cooldown.IsCompleted()) 
                _gameContext.RespawnCharacter(_character);
        }
    }
}