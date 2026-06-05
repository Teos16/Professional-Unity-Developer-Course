using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class TransportDestroyedController : IPlayerContextInit, IPlayerContextFixedTick
    {
        private IGameEntity _character;
        
        public void Init(IPlayerContext context)
        {
            _character = context.GetValue(PlayerContextAPI.Character);
        }

        public void FixedTick(IPlayerContext entity, float deltaTime)
        {
            IGameEntity transport = _character.GetCurrentTransport().Value;
            if (transport != null && transport.IsDead())
                _character.ExitTransport();
        }
    }
}