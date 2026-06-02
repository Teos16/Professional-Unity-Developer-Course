using Atomic.Entities;
using Game;
using UnityEngine;

namespace SampleGame
{
    public sealed class CarInstaller : SceneEntityInstaller
    {
        [SerializeField] private CarController carController;
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private InteractibleInstaller _interactibleInstaller;

        public override void Install(IEntity entity)
        {
            _transformInstaller.Install(entity);
            _interactibleInstaller.Install(entity);

            entity.GetInteractCondition().Add(target => target.HasCharacterTag());
            entity.GetInteractAction().Add(character => character.EnterCar(carController));
        }
    }
}