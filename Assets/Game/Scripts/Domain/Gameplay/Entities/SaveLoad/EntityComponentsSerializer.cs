using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using SampleGame.Gameplay;
using UnityEngine;

namespace SampleGame.Gameplay
{
    public sealed class EntityComponentsSerializer
    {
        private readonly List<IComponentSerializer> _serializers;

        public EntityComponentsSerializer(List<IComponentSerializer> serializers = null)
        {
            _serializers = serializers ?? new List<IComponentSerializer>();
            _serializers = _serializers
                .OrderBy(s => s is TargetObjectSerializer ? 1 : 0)
                .ToList();
        }

        public Dictionary<string, object> Serialize(GameObject go)
        {
            Dictionary<string, object> data = new();
            
            foreach (IComponentSerializer serializer in _serializers)
                serializer.Serialize(go, data);

            return data;
        }

        public void Deserialize(GameObject go, Dictionary<string, object> raw)
        {
            JObject components = JObject.FromObject(raw);

            foreach (IComponentSerializer serializer in _serializers)
            {
                JToken token = components[serializer.Key];
                serializer.Deserialize(go, token);
            }
        }
    }
}