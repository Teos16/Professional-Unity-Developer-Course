using UnityEngine;

namespace Game
{
    public sealed class TakeDamageSoundComponent : MonoBehaviour
    {
        [SerializeField] AudioClip _audioClip;
        
        private AudioSource _audioSource;
        private HealthComponent _healthComponent;
        
        private void Awake()
        {
            _healthComponent = GetComponentInParent<HealthComponent>(); 
            _audioSource = GetComponentInChildren<AudioSource>();
        }

        private void OnEnable() => _healthComponent.OnHealthChanged += OnDamageTaken;
        
        private void OnDisable() => _healthComponent.OnHealthChanged -= OnDamageTaken;
        
        private void OnDamageTaken(float _)
        {
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}