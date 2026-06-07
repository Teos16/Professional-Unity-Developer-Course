using UnityEngine;

namespace Game.Gameplay
{
    public sealed class AreaEffector : MonoBehaviour
    {
        [SerializeReference] private IGameEntityAspect[] _aspects;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IGameEntity entity))
            {
                foreach (IGameEntityAspect aspect in _aspects)
                {
                    aspect.Apply(entity);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IGameEntity entity))
            {
                foreach (IGameEntityAspect aspect in _aspects)
                {
                    aspect.Discard(entity);
                }
            }
        }
    }
}