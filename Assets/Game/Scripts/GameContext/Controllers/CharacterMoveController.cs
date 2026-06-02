using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CharacterMoveController : IEntityInit, IEntityTick
    {
        private IEntity _character;
        
        public void Init(IEntity entity)
        {
            _character = entity.GetCharacter();
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.UpArrow))
                direction.z = 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                direction.z = -1;

            if (Input.GetKey(KeyCode.LeftArrow))
                direction.x = -1;
            else if (Input.GetKey(KeyCode.RightArrow))
                direction.x = 1;
            
            _character.GetMoveRequest().Invoke(direction);
        }
    }
}