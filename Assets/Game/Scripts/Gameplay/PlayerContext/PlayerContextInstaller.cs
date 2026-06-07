using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PlayerContextInstaller : SceneEntityInstaller<IPlayerContext>
    {
        [SerializeField]
        private GameEntity _characterPrefab;

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private Const<Vector3> _cameraOffset;

        [SerializeField]
        private InputMap _inputMap;

        [SerializeField]
        private Cooldown _respawnCooldown = 5;

        [SerializeField]
        private Const<TeamType> _teamType;

        [SerializeField]
        private ReactiveVariable<int> _initialMana = 25;
        
        [SerializeField]
        private AbilitiesInstaller _abilitiesInstaller;

        public override void Install(IPlayerContext context)
        {
            GameContext gameContext = GameContext.Instance;

            _abilitiesInstaller.Install(context);
            
            context.AddValue(PlayerContextAPI.Camera, _camera);
            context.AddValue(PlayerContextAPI.InputMap, _inputMap);
            context.AddValue(PlayerContextAPI.RespawnCooldown, _respawnCooldown);
            context.AddValue(PlayerContextAPI.Team, _teamType);
            context.AddValue(PlayerContextAPI.Score, new ReactiveVariable<int>());
            context.AddValue(PlayerContextAPI.Mana, _initialMana);

            if (AtomicUtils.IsPlayMode()) 
                context.AddValue(PlayerContextAPI.Character, SceneEntity.Create(_characterPrefab, transform));

            context.AddBehaviour(new CharacterInputController(gameContext));
            context.AddBehaviour(new CharacterRespawnController(gameContext));
            context.AddBehaviour(new CameraFollowController(_cameraOffset));
            context.AddBehaviour(new TransportInputController(gameContext));
            context.AddBehaviour(new CharacterInitController(gameContext));
            context.AddBehaviour<TransportDestroyedController>();
        }
    }
}