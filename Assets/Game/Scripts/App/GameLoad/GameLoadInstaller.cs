using System;
using Atomic.Entities;
using Game.Gameplay;
using Game.UI;
using UnityEngine;

namespace Game.App
{
    [Serializable]
    public sealed class GameLoadInstaller : IEntityInstaller<IAppContext>
    {
        [SerializeField]
        private GameContext _gameContextPrefab;

        [SerializeField]
        private GameUI _gameUIContextPrefab;

        public void Install(IAppContext context)
        {
            context.AddGameContextPrefab(_gameContextPrefab);
            context.AddGameUIPrefab(_gameUIContextPrefab);
        }
    }
}