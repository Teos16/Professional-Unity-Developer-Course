using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public abstract class PickUpInstaller : GameEntityInstaller
    {
        [SerializeField]
        private TransformInstaller _transformInstaller;
        
        [SerializeField]
        private InteractibleInstaller _interactibleInstaller;
        
        public override void Install(IGameEntity entity)
        {
            _transformInstaller.Install(entity);
            _interactibleInstaller.Install(entity);
        }
    }
}