using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Gameplay
{
    public sealed class GameContextInstaller : SceneEntityInstaller<IGameContext>
    {
        private const string WORLD_TRANSFORM = "[World]";

        [SerializeField] private GameEntityPool _bulletPool;
        [SerializeField] private PrefabEntityPool _prefabPool;
        [SerializeField] private GameCycleInstaller _gameCycleInstaller;
        [SerializeField] private SpawnPointsInstaller _spawnPointsInstaller;
        
        public override void Install(IGameContext gameContext)
        {
            _gameCycleInstaller.Install(gameContext);
            _spawnPointsInstaller.Install(gameContext);

            gameContext.AddBulletPool(_bulletPool);
            gameContext.AddPrefabPool(_prefabPool);
            gameContext.AddWorldTransform(GameObject.Find(WORLD_TRANSFORM).transform);

            InstallPlayers(gameContext);
            SceneEntity.InstallAll<GameEntity>(SceneManager.GetActiveScene());
        }

        private void InstallPlayers(IGameContext gameContext)
        {
            PlayerContext[] playerContexts = FindObjectsByType<PlayerContext>(FindObjectsSortMode.None);
            Dictionary<TeamType, IPlayerContext> playerMap = new Dictionary<TeamType, IPlayerContext>();
            foreach (PlayerContext playerContext in playerContexts)
            {
                playerContext.Install();
                TeamType team = playerContext.GetValue(PlayerContextAPI.Team).Value;
                playerMap.Add(team, playerContext);
            }
            
            gameContext.AddPlayers(playerMap);
        }
    }
}