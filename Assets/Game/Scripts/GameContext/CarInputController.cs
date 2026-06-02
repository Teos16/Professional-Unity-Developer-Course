using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class CarInputController : IEntityInit, IEntityTick
    {
        private IEntity _character;
        
        public void Init(IEntity entity)
        {
            _character = entity.GetCharacter();
        }
        
        public void Tick(IEntity entity, float deltaTime)
        {
            CarController car = _character.GetCurrentCar().Value;
            if (car == null)
                return;

            ProcessMove(car);
            ProcessExit();
        }

        private void ProcessMove(CarController car)
        {
            float forwardDirection = Input.GetAxis("Vertical");
            float turnDirection = Input.GetAxis("Horizontal");
 
            car.SetInput(forwardDirection, turnDirection);
            car.SetBrake(Input.GetKey(KeyCode.Space));
        }

        private void ProcessExit()
        {
            if (Input.GetKeyDown(KeyCode.Z)) 
                _character.ExitCar();
        }
    }
}