using UnityEngine;

namespace SampleGame.Components
{
    public sealed class FireComponentView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private AudioSource _audioSource;
        
        private FireRequestComponent _fireRequestComponent;
        
        private void Awake() => _fireRequestComponent = this.GetComponentInParent<FireRequestComponent>();

        private void OnEnable() => _fireRequestComponent.OnFire += this.OnFireRequest;

        private void OnDisable() => _fireRequestComponent.OnFire -= this.OnFireRequest;

        private void OnFireRequest()
        {
            _particleSystem.Play(withChildren: true);
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.Play();
        }
    }
}