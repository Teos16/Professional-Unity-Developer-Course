using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class JumpInputController : IGameEntityInit, IGameEntityTick
    {
        private IRequest _request;
        
        public void Init(IGameEntity entity)
        {
            _request = entity.GetJumpRequest();
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                _request.Invoke();
        }
    }
}