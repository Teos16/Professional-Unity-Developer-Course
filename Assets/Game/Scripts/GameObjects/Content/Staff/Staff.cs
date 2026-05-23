using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PushRigidbodyComponent), typeof(OverlapComponent))]
    public sealed class Staff : MonoBehaviour,
        PushRigidbodyComponent.ICondition
    {
        public event Action OnPush;
        public event Action OnToss;

        [SerializeField] private MoveRigidbodyConfig _pushConfig;
        [SerializeField] private MoveRigidbodyConfig _tossConfig;
        
        private PushRigidbodyComponent _pushRigidbodyComponent;
        private OverlapComponent _component;

        private readonly Dictionary<MoveRigidbodyConfig, float> _lastUsedTimes = new();
        
        private float _globalUnlockTime;
        
        private void Awake()
        {
            _pushRigidbodyComponent = GetComponent<PushRigidbodyComponent>();
            _component = GetComponent<OverlapComponent>();

            _lastUsedTimes[_pushConfig] = -100f;
            _lastUsedTimes[_tossConfig] = -100f;

            _pushRigidbodyComponent.SetCondition(this);
        }

        public void Push() => TryExecute(_pushConfig, OnPush);

        public void Toss() => TryExecute(_tossConfig, OnToss);

        private void TryExecute(MoveRigidbodyConfig config, Action eventToInvoke)
        {
            if (Time.time < _globalUnlockTime)
                return;

            if (Time.time < _lastUsedTimes[config] + config.Cooldown)
                return;

            Execute(config);
            _lastUsedTimes[config] = Time.time;
            eventToInvoke?.Invoke();

            float lockDuration = config.Duration + config.Lag;
            if (lockDuration > 0f)
                _globalUnlockTime = Time.time + lockDuration;
        }

        private void Execute(MoveRigidbodyConfig config)
        {
            int count = _component.Detect(out Collider2D[] colliders);
            if (count == 0) return;
            
            for (int i = 0; i < count; i++)
            {
                Collider2D col = colliders[i];
                if (col == null || col.attachedRigidbody == null) 
                    continue;
                _pushRigidbodyComponent.TryPush(col.attachedRigidbody, config, transform.position);
            }
        }
        
        bool PushRigidbodyComponent.ICondition.Evaluate() => true;
    }
}