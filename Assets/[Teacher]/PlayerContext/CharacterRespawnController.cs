// using Atomic.Elements;
//
// namespace Game.Gameplay
// {
//     public sealed class CharacterRespawnController : IPlayerContextInit, IPlayerContextDispose, IPlayerContextFixedTick
//     {
//         private readonly IGameContext _gameContext;
//
//         private IGameEntity _character;
//         private ICooldown _respawnCooldown;
//
//         public CharacterRespawnController(IGameContext gameContext)
//         {
//             _gameContext = gameContext;
//         }
//
//         public void Init(IPlayerContext playerContext)
//         {
//             _respawnCooldown = playerContext.GetRespawnCooldown();
//             _character = playerContext.GetCharacter();
//             _character.GetDeathEvent().OnEvent += this.OnDeath;
//         }
//
//         public void Dispose(IPlayerContext entity)
//         {
//             _character.GetDeathEvent().OnEvent -= this.OnDeath;
//         }
//
//         private void OnDeath()
//         {
//             _respawnCooldown.ResetTime();
//         }
//
//         public void FixedTick(IPlayerContext playerContext, float deltaTime)
//         {
//             if (!_respawnCooldown.IsPlaying()) 
//                 return;
//             
//             _respawnCooldown.Tick(deltaTime);
//             if (_respawnCooldown.IsCompleted()) 
//                 playerContext.RespawnCharacter(_gameContext);
//         }
//     }
// }