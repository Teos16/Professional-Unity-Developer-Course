using SampleGame.Components;
using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(RotateComponent), typeof(FireRequestComponent), typeof(HealthComponent))]
    [RequireComponent(typeof(CooldownComponent), typeof(FireBulletComponent))]
    [RequireComponent(typeof(AttackTargetComponent), typeof(RotateAtTargetComponent), typeof(DetectTargetComponent))]
    public sealed class Tower : MonoBehaviour
    {
        private FireRequestComponent _fireRequestComponent;
        private FireBulletComponent _fireBulletComponent;
        private CooldownComponent _cooldownComponent;
        private HealthComponent _healthComponent;
        private AttackTargetComponent _attackTargetComponent;
        private RotateAtTargetComponent _rotateAtTargetComponent;
        private DetectTargetComponent _detectTargetComponent;
        
        private void Awake()
        {
            _fireRequestComponent = this.GetComponent<FireRequestComponent>();
            _fireBulletComponent = this.GetComponent<FireBulletComponent>();
            _cooldownComponent = this.GetComponent<CooldownComponent>();
            _healthComponent = this.GetComponent<HealthComponent>();
            _attackTargetComponent = this.GetComponent<AttackTargetComponent>();
            _rotateAtTargetComponent = this.GetComponent<RotateAtTargetComponent>();
            _detectTargetComponent = this.GetComponent<DetectTargetComponent>();
            
            _fireRequestComponent.SetCondition(() => _healthComponent.IsAlive() && _cooldownComponent.IsExpired);
            _fireRequestComponent.SetAction(() =>
            {
                _fireBulletComponent.Fire();
                _cooldownComponent.Reset();
            });
            
            _attackTargetComponent.SetCondition(_healthComponent.IsAlive);
            _rotateAtTargetComponent.SetCondition(_healthComponent.IsAlive);
        }

        private void OnEnable() => _healthComponent.OnHealthEmpty += OnHealthEmpty;
        
        private void OnDisable() => _healthComponent.OnHealthEmpty -= OnHealthEmpty;

        private void OnHealthEmpty() => Destroy(this.gameObject);
    }
}