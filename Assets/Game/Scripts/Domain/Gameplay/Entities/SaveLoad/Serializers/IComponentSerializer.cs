using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace SampleGame.Gameplay
{
    public interface IComponentSerializer
    {
        string Key { get; }

        void Serialize(GameObject go, Dictionary<string, object> data);

        void Deserialize(GameObject go, JToken data);
    }
    
    public interface IComponentSerializer<T> : IComponentSerializer
    {
        void IComponentSerializer.Serialize(GameObject go, Dictionary<string, object> data)
        {
            if (TrySerialize(go, out T value))
                data[Key] = value;
        }

        void IComponentSerializer.Deserialize(GameObject go, JToken data)
        {
            if (data != null)
                Deserialize(go, data.ToObject<T>());
        }

        new bool TrySerialize(GameObject go, out T data);
        
        new void Deserialize(GameObject go, T data);
    }
}