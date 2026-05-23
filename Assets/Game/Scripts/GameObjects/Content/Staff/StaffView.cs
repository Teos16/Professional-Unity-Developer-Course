using UnityEngine;

namespace Game
{
    public sealed class StaffView : MonoBehaviour
    {
        private static readonly int Push = Animator.StringToHash("BlowForward");
        private static readonly int Toss = Animator.StringToHash("BlowUp");

        [SerializeField] private AudioClip _pushClip;
        [SerializeField] private AudioClip _tossClip;
        [SerializeField] private ParticleSystem _pushParticles;
        [SerializeField] private ParticleSystem _tossParticles;
        [SerializeField] private Staff _staff;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Animator _animator;

        private void OnEnable()
        {
            _staff.OnPush += OnPush;
            _staff.OnToss += OnToss;
        }
        
        private void OnDisable()
        {
            _staff.OnPush -= OnPush;
            _staff.OnToss -= OnToss;
        }

        private void OnPush()
        {
            _animator.SetTrigger(Push);
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.PlayOneShot(_pushClip);
            _pushParticles.Play();
        }

        private void OnToss()
        {
            _animator.SetTrigger(Toss);
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            _audioSource.PlayOneShot(_tossClip);
            _tossParticles.Play();
        }
    }
}