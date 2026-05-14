using UnityEngine;

namespace Game
{
    public sealed class OnDeathAnimationComponent : MonoBehaviour
    {
        private static readonly int Death = Animator.StringToHash("Death");
        
        private Animator _animator;
        private HealthComponent _healthComponent; 
        
        private void Awake()
        {
            _healthComponent = GetComponentInParent<HealthComponent>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void OnEnable() => _healthComponent.OnDied += OnDeath;
        
        private void OnDisable() => _healthComponent.OnDied -= OnDeath;
        
        private void OnDeath() => _animator.SetTrigger(Death);
    }
}