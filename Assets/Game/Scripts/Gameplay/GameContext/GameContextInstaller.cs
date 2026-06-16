using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using Game.UI;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class GameContextInstaller : SceneEntityInstaller<IGameContext>
    {
        [SerializeField] private GameEntityPool _bulletPool;
        [SerializeField] private GameEntity _player;
        
        public override void Install(IGameContext context)
        {
            InstallGameEntities();
            GameUI ui = InstallUI();

            context.AddValue(GameContextAPI.BulletPool, _bulletPool);
            context.AddValue(GameContextAPI.Player, _player);
            context.AddValue(GameContextAPI.Score, new ReactiveVariable<int>());
         
            context.AddBehaviour(new CharacterMoveController(ui));
            context.AddBehaviour(new CharacterAttackController(ui));
        }

        private void InstallGameEntities()
        {
            GameEntity[] entities = FindObjectsByType<GameEntity>(FindObjectsSortMode.None);
            
            GameEntity[] sortedEntities = entities
                .OrderByDescending(e => e.HasTag(GameEntityAPI.PlayerTag))
                .ToArray();
            
            foreach (GameEntity gameEntity in sortedEntities)
                gameEntity.Install();
        }

        private static GameUI InstallUI()
        {
            GameUI ui = FindFirstObjectByType<GameUI>();
            ui.Install();
            return ui;
        }
    }
}