using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public static class TransportUseCase
    {
        public static bool EnterTransport(this IGameEntity character, IGameEntity transport)
        {
            IVariable<IGameEntity> carVariable = character.GetCurrentTransport();
            if (carVariable.Value != null)
                return false;

            carVariable.Value = transport;

            Transform characterTransform = character.GetTransform();
            characterTransform.gameObject.SetActive(false);

            characterTransform.SetParent(transport.GetTransform());
            characterTransform.localPosition = Vector3.zero;
            characterTransform.localRotation = Quaternion.identity;

            transport.GetTeam().Value = character.GetTeam().Value;
            transport.GetActivateAction().Invoke();
            return true;
        }

        public static bool ExitTransport(this IGameEntity character)
        {
            IVariable<IGameEntity> transportVariable = character.GetCurrentTransport();
            IGameEntity transport = transportVariable.Value;
            if (transport == null)
                return false;
            
            transportVariable.Value = null;
            
            Transform characterTransform = character.GetTransform();
            characterTransform.SetParent(null);
            
            Transform exitPoint = transport.GetExitPoint();
            characterTransform.SetPositionAndRotation(exitPoint.position, exitPoint.rotation);
            characterTransform.gameObject.SetActive(true);
            
            transport.GetDeactivateAction().Invoke();
            transport.GetTeam().Value = TeamType.NEUTRAL;
            return true;
        }
    }
}