using Atomic.Elements;
using Atomic.Entities;
using Game;
using UnityEngine;

namespace SampleGame
{
    public static class CarUseCase
    {
        public static bool EnterCar(this IEntity character, CarController car)
        {
            IVariable<CarController> carVariable = character.GetCurrentCar();
            if (carVariable.Value != null)
                return false;

            carVariable.Value = car;

            Transform characterTransform = character.GetTransform();
            characterTransform.gameObject.SetActive(false);

            characterTransform.SetParent(car.transform);
            characterTransform.localPosition = Vector3.zero;
            characterTransform.localRotation = Quaternion.identity;
            
            car.StartCar();

            return true;
        }

        public static bool ExitCar(this IEntity character)
        {
            IVariable<CarController> carVariable = character.GetCurrentCar();

            CarController car = carVariable.Value;
            if (car == null)
                return false;

            carVariable.Value = null;

            Transform characterTransform = character.GetTransform();

            characterTransform.SetParent(null);
            characterTransform.SetPositionAndRotation(car.transform.position, car.transform.rotation);
            characterTransform.gameObject.SetActive(true);
            
            Debug.Log("Exit CAR");
            car.StopCar();

            return true;
        }
    }
}