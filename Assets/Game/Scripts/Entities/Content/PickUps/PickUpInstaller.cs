using Atomic.Entities;
using UnityEngine;

namespace Game
{
    public abstract class PickUpInstaller : SceneEntityInstaller
    {
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private InteractibleInstaller _interactibleInstaller;
        
        public override void Install(IEntity entity)
        {
            _transformInstaller.Install(entity);
            _interactibleInstaller.Install(entity);
        }
    }
}