using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public sealed class GameContextInstaller : SceneEntityInstaller
    {
        [SerializeField] private SceneEntityPool _bulletPool;
        [SerializeField] private SceneEntity _character;
        
        public override void Install(IEntity entity)
        {
            entity.AddBulletPool(_bulletPool);
            entity.AddCharacter(_character);
            entity.AddBehaviour<CharacterMoveController>();
            entity.AddBehaviour<CharacterFireController>();
            entity.AddBehaviour<CharacterDropController>();
            entity.AddBehaviour<CarInputController>();
            entity.AddBehaviour<CharacterInteractController>();
        }
    }
}