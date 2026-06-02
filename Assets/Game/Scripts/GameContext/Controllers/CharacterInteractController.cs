using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class CharacterInteractController : IEntityInit, IEntityTick
    {
        private IEntity _character;

        public void Init(IEntity entity)
        {
            _character = entity.GetCharacter();
        }

        public void Tick(IEntity entity, float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
                _character.InteractWith(_character.GetTargetInteractible().Value);
        }
    }
}