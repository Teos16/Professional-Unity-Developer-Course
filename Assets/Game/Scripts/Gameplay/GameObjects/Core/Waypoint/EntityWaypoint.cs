using UnityEngine;

namespace SampleGame
{
    public class EntityWaypoint : IWaypoint
    {
        private readonly GameObject _go;
        
        public EntityWaypoint(GameObject go) => _go = go;

        public Vector3 GetPosition => _go.transform.position;
        
        public bool IsValid
        {
            get
            {
                if(_go == null ||
                   !_go.activeInHierarchy ||
                   !_go.TryGetComponent(out HealthComponent health) ||
                    health.IsDead)
                    return false;
                    
                return true;
            }
        }
    }
}