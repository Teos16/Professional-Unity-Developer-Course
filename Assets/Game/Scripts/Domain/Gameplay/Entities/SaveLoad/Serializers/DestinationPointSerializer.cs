using SampleGame.Common;
using UnityEngine;

namespace SampleGame.Gameplay
{
    public sealed class DestinationPointSerializer : IComponentSerializer<SerializedVector3>
    {
        public string Key => "DestinationPoint";
        
        public bool TrySerialize(GameObject go, out SerializedVector3 data)
        {
            if(go.TryGetComponent(out DestinationPoint destinationPoint))
            {
                data = destinationPoint.Value;
                return true;
            }
            
            data = default;
            return false;
        }

        public void Deserialize(GameObject go, SerializedVector3 data)
        {
            if(go.TryGetComponent(out DestinationPoint destinationPoint))
                destinationPoint.Value = data;
        }
    }
}