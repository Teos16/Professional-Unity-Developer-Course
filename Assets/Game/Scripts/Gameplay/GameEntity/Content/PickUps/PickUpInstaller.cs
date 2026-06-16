using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    public abstract class PickUpInstaller : GameEntityInstaller
    {
        [BoxGroup("BASE"), SerializeField] private TransformInstaller _transformInstaller;
        [BoxGroup("BASE"), SerializeField] private InteractableInstaller _interactibleInstaller;
        
        public override void Install(IGameEntity entity)
        {
            _transformInstaller.Install(entity);
            _interactibleInstaller.Install(entity);
        }
    }
}