using UnityEngine;

namespace Game
{
    public sealed class OnDeathComponent : MonoBehaviour
    {
        private Collider2D[] _colliders;
        
        private void Awake() => _colliders = GetComponents<Collider2D>();
        
        public void TurnOffPhysics()
        {
            foreach (Collider2D col in _colliders) 
                col.isTrigger = true;
        }
    }
}