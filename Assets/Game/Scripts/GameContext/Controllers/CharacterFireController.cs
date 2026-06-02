using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CharacterFireController : IEntityInit, IEntityTick
    {
        private IEntity _character;
        
        public void Init(IEntity entity)
        {
            _character = entity.GetCharacter();
        }
        
        public void Tick(IEntity entity, float deltaTime)
        {
            if (Input.GetKey(KeyCode.Space))
                _character.GetFireRequest().Invoke();
        }
    }
}