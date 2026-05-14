using System;
using UnityEngine;

namespace Game
{
    public sealed class Lava : MonoBehaviour
    {
        private TriggerComponent _trigger;

        private void Awake() => _trigger = GetComponent<TriggerComponent>();

        private void OnEnable() => _trigger.OnEntered += OnTriggerEntered;

        private void OnDisable() => _trigger.OnEntered -= OnTriggerEntered;

        private void OnTriggerEntered(Collider2D col)
        {
            HealthComponent health = col.GetComponent<HealthComponent>();
            if (health != null)
                health.SetZero();
        }
    }
}