using System;
using Atomic.Entities;
using Cysharp.Threading.Tasks;
using Game.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.App
{
    public static class GameLoadUseCase
    {
        public static UniTask LoadGame(this IAppContext context) => 
            LoadGame(context, context.GetCurrentLevel().Value);

        public static async UniTask LoadGame(this IAppContext context, int level)
        {
            if (level <= 0 || level > context.GetMaxLevel().Value)
                throw new ArgumentOutOfRangeException(nameof(level));

            await LoadLevelScene(level);
            LoadGameSystem(context);
        }

        private static async UniTask LoadLevelScene(int level)
        {
            string sceneName = $"Game (Level{level})";
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            await operation;
        }

        private static void LoadGameSystem(IAppContext context)
        {
            GameContext gameContext = SceneEntity.Create(context.GetGameContextPrefab());
            gameContext.AddBehaviour(new LevelIncrementController(context));
            
            SceneEntity.Create(context.GetGameUIPrefab());
        }
    }
}