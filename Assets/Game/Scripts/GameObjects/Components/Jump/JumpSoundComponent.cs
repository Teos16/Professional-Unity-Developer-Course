using UnityEngine;

namespace Game
{
    public sealed class JumpSoundComponent : MonoBehaviour
    {
        [SerializeField] AudioClip _audioClip;

        private AudioSource _audioSource;
        private JumpRequestComponent _jumpRequestComponent;

        private void Awake()
        {
            _jumpRequestComponent = GetComponentInParent<JumpRequestComponent>();
            _audioSource = GetComponentInChildren<AudioSource>();
        }

        private void OnEnable() => _jumpRequestComponent.OnJumped += OnJump;
        
        private void OnDisable() => _jumpRequestComponent.OnJumped -= OnJump;
        
        private void OnJump()
        {
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}