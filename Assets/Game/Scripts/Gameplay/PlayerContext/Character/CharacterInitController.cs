using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class CharacterInitController : IPlayerContextInit
    {
        private readonly IGameContext _gameContext;
        
        public CharacterInitController(IGameContext gameContext) => 
            _gameContext = gameContext;

        public void Init(IPlayerContext context)
        {
            IGameEntity character = context.GetValue(PlayerContextAPI.Character);
            IValue<TeamType> team = context.GetValue(PlayerContextAPI.Team);
            
            character.GetTeam().Value = team.Value;
            _gameContext.RespawnCharacter(character);
        }
    }
}