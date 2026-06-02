using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CharacterDropController : IEntityInit, IEntityTick
    {
        private IEntity _character;
        
        public void Init(IEntity entity)
        {
            _character = entity.GetCharacter();
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Q)) 
                _character.DropWeapon();
        }
    }
}