using Modules.Entities;
using UnityEngine;

namespace SampleGame.Gameplay
{
    public sealed class TargetObjectSerializer : IComponentSerializer<int>
    {
        public string Key => "Target";
        
        private readonly EntityWorld _world;
        
        public TargetObjectSerializer(EntityWorld world) => _world = world;

        public bool TrySerialize(GameObject go, out int data)
        {
            if(go.TryGetComponent(out TargetObject target))
            {
                data = target.Value == null ? -1 : target.Value.Id;
                return true;
            }
            data = -1;
            return false;
        }

        public void Deserialize(GameObject go, int data)
        {
            if (go.TryGetComponent(out TargetObject target))
            {
                if(data == -1 || !_world.Has(data))
                    target.Value = null;
                else
                    target.Value = _world.Get(data);
            }
        }
    }
}