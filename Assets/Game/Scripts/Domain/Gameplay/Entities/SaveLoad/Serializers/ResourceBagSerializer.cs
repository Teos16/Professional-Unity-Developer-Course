using SampleGame.Common;
using UnityEngine;

namespace SampleGame.Gameplay
{
    public struct ResourceBagData
    {
        public ResourceType Type;
        public int Current;
    }
    
    public sealed class ResourceBagSerializer : IComponentSerializer<ResourceBagData>
    {
        public string Key => "ResourceBag";
        
        public bool TrySerialize(GameObject go, out ResourceBagData data)
        {
            if (go.TryGetComponent(out ResourceBag resourceBag))
            {
                ResourceBagData bag = new ResourceBagData()
                {
                    Type = resourceBag.Type,
                    Current = resourceBag.Current
                };
                
                data = bag;
                return true;
            }
            data = default;
            return false;
        }

        public void Deserialize(GameObject go, ResourceBagData data)
        {
            if (go.TryGetComponent(out ResourceBag resourceBag))
            {
                resourceBag.Type = data.Type;
                resourceBag.Current = data.Current;
            }
        }
    }
}