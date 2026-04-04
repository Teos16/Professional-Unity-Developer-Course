using System;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class OutOfBordersController : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IWorldBounds _bounds;
        private readonly GameCycle _gameCycle;

        public OutOfBordersController(ISnake snake, IWorldBounds bounds, GameCycle gameCycle)
        {
            _snake = snake;
            _bounds = bounds;
            _gameCycle = gameCycle;
        }

        public void Initialize() => _snake.OnMoved += OnOutOfBorders;

        public void Dispose() => _snake.OnMoved -= OnOutOfBorders;

        private void OnOutOfBorders(Vector2Int position)
        {
            if (!_bounds.IsInBounds(position)) 
                _gameCycle.Lose();
        }
    }
}