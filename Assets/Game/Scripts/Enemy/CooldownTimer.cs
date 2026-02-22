using UnityEngine;

namespace Game.Enemy
{
    public sealed class CooldownTimer : MonoBehaviour
    {
        private float _minCooldown;
        private float _maxCooldown;
        private float _lastTime;
        private float _cooldown;

        private void Awake() => Reset();

        private void OnEnable() => Reset();

        public void SetCooldownLimits(float min, float max)
        {
            _minCooldown = min;
            _maxCooldown = max;
        }

        public void Reset()
        {
            _cooldown = Random.Range(_minCooldown, _maxCooldown);
            _lastTime = Time.fixedTime;
        }

        public bool IsReady() => Time.fixedTime - _lastTime >= _cooldown;
    }
}