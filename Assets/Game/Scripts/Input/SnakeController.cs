using Modules;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class SnakeController : ITickable
    {
        private ISnake _snake;
        private InputControls _inputControls;

        public SnakeController(ISnake snake, InputControls inputControls)
        {
            _snake = snake;
            _inputControls = inputControls;
        }

        public void Tick()
        {
            if(Input.GetKey(_inputControls.Left))
                _snake.Turn(SnakeDirection.LEFT);
            else if(Input.GetKey(_inputControls.Right))
                _snake.Turn(SnakeDirection.RIGHT);
            else if(Input.GetKey(_inputControls.Up))
                _snake.Turn(SnakeDirection.UP);
            else if(Input.GetKey(_inputControls.Down))
                _snake.Turn(SnakeDirection.DOWN);
        }
    }
}