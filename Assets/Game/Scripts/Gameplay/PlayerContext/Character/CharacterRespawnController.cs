using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public class CharacterRespawnController : IPlayerContextInit, IPlayerContextDispose, IPlayerContextFixedTick
    {
        private readonly IGameContext _gameContext;
        
        private ICooldown _cooldown;
        private IGameEntity _character;
        private Subscription<int> _subscription;
        
        public CharacterRespawnController(IGameContext gameContext) => 
            _gameContext = gameContext;

        public void Init(IPlayerContext context)
        {
            _character = context.GetValue(PlayerContextAPI.Character);
            _cooldown = context.GetValue(PlayerContextAPI.RespawnCooldown);
            _subscription = _character.GetHealth().Subscribe(OnHealthChanged);
        }

        public void Dispose(IPlayerContext entity)
        {
            _subscription.Dispose();
        }

        public void FixedTick(IPlayerContext entity, float deltaTime)
        {
            if(_cooldown.IsCompleted())
                return;
            
            _cooldown.Tick(deltaTime);
            if (_cooldown.IsCompleted()) 
                _gameContext.RespawnCharacter(_character);
        }

        private void OnHealthChanged(int health)
        {
            if (health <= 0) 
                _cooldown.ResetTime();
        }
    }
}