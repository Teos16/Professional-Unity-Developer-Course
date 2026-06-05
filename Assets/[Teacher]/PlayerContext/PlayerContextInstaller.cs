// using Atomic.Elements;
// using Atomic.Entities;
// using UnityEngine;
//
// namespace Game.Gameplay
// {
//     public sealed class PlayerContextInstaller : SceneEntityInstaller<IPlayerContext>
//     {
//         [SerializeField]
//         private GameEntity _characterPrefab;
//
//         [SerializeField]
//         private Camera _camera;
//
//         [SerializeField]
//         private Const<Vector3> _cameraOffset;
//
//         [SerializeField]
//         private Const<TeamType> _teamType;
//
//         [SerializeField]
//         private TeamCatalog _teamCatalog;
//
//         [SerializeField]
//         private ReactiveVariable<int> _score;
//
//         [SerializeField]
//         private Cooldown _respawnCooldown = 5;
//         
//         public override void Install(IPlayerContext context)
//         {
//             GameContext gameContext = GameContext.Instance;
//
//             context.AddInputMap(_teamCatalog.GetTeam(_teamType).InputMap);
//             context.AddCamera(_camera);
//             context.AddScore(_score);
//             context.AddTeam(_teamType);
//             context.AddRespawnCooldown(_respawnCooldown);
//
//             context.AddBehaviour(new CameraFollowController(_cameraOffset));
//             context.AddBehaviour(new CharacterInputController(gameContext));
//             context.AddBehaviour(new CharacterRespawnController(gameContext));
//             context.AddBehaviour(new CharacterInitializer(gameContext));
//             context.AddBehaviour<TransportInputController>();
//             
//             if (AtomicUtils.IsPlayMode()) 
//                 context.AddCharacter(GameEntity.Create(_characterPrefab, this.transform));
//
//             _camera.targetDisplay = _teamCatalog.GetTeam(_teamType).CameraDisplay;
//             // _character.WhenInstall(() => _character.GetTeam().Value = _teamType);
//         }
//     }
// }