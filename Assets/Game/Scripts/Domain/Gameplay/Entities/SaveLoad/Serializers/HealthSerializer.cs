using UnityEngine;

namespace SampleGame.Gameplay
{
    public sealed class HealthSerializer : IComponentSerializer<int>
    {
        public string Key => "Health";
        
        public bool TrySerialize(GameObject go, out int data)
        {
            if(go.TryGetComponent(out Health health))
            {
                data = health.Current;
                return true;
            }
            
            data = 0;
            return false;
        }

        public void Deserialize(GameObject go, int data)
        {
            if(go.TryGetComponent(out Health health)) 
                health.Current = data;
        }
    }
}