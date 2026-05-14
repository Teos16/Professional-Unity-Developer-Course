using UnityEngine;

namespace Game
{
    public sealed class CooldownComponent : MonoBehaviour  
    {
        [SerializeField] private float _duration = 1f;

        private float _currentTime;

        public bool IsExpired => Time.time - _currentTime >= _duration;
        
        private void Awake() => _currentTime = Time.time - _duration;
        
        public void SetDuration(float duration) => _duration = duration;

        public void Reset() => _currentTime = Time.time;
    }
}