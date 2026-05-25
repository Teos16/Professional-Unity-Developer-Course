using UnityEngine;

namespace SampleGame.Gameplay
{
    public sealed class CountdownSerializer : IComponentSerializer<float>
    {
        public string Key => "Countdown";
        
        public bool TrySerialize(GameObject go, out float data)
        {
            if(go.TryGetComponent(out Countdown countdown))
            {
                data = countdown.Current;
                return true;
            }
            data = 0;
            return false;
        }

        public void Deserialize(GameObject go, float data)
        {
            if(go.TryGetComponent(out Countdown countdown)) countdown.Current = data;
        }
    }
}