using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyTriggerZone : MonoBehaviour
    {
        [SerializeField] private GameEntity[] _zombies;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IGameEntity target))
                if (target.IsPlayer())
                {
                    foreach (var zombie in _zombies) 
                        zombie.GetValue(GameEntityAPI.Target).Value = target;
                }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IGameEntity target))
                if (target.IsPlayer())
                {
                    foreach (var zombie in _zombies) 
                        zombie.GetValue(GameEntityAPI.Target).Value = null;
                }
        }
    }
}