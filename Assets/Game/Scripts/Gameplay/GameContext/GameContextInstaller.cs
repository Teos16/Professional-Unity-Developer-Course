using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Gameplay
{
    public sealed class GameContextInstaller : SceneEntityInstaller<IGameContext>
    {
        [SerializeField] private GameEntityPool _bulletPool;
        [SerializeField] private GameEntity _player;
        
        public override void Install(IGameContext context)
        {
            SceneEntity.InstallAll<GameEntity>(SceneManager.GetActiveScene());
            context.AddValue(GameContextAPI.BulletPool, _bulletPool);
            context.AddValue(GameContextAPI.Player, _player);
            context.AddValue(GameContextAPI.Score, new ReactiveVariable<int>());
        }
    }
}