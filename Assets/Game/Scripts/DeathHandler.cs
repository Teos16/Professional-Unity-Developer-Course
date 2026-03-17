using System;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class DeathHandler : IInitializable, IDisposable
    {
        public event Action OnDeath;
        
        private ISnake _snake;
        private IWorldBounds _worldBounds;
        
        public DeathHandler(ISnake snake, IWorldBounds worldBounds)
        {
            _snake = snake;
            _worldBounds = worldBounds;
        }
        
        public void Initialize()
        {
            _snake.OnMoved += OnSnakeMoved;
            _snake.OnSelfCollided += OnSnakeSelfCollided;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnSnakeMoved;
            _snake.OnSelfCollided -= OnSnakeSelfCollided;
        }

        private void OnSnakeMoved(Vector2Int position)
        {
            if(!_worldBounds.IsInBounds(position))
                OnDeath?.Invoke();
        }
        
        private void OnSnakeSelfCollided() => OnDeath?.Invoke();
    }
}