// using UnityEngine;
//
// namespace SampleGame
// {
//     public sealed class DeathComponentView : MonoBehaviour
//     {
//         private HealthComponent _healthComponent;
//
//         [SerializeField]
//         private ParticleSystem _particleSystem;
//
//         private void Awake()
//         {
//             _healthComponent = this.GetComponent<HealthComponent>();
//         }
//
//         private void OnEnable()
//         {
//             _healthComponent.OnHealthEmpty += this.OnDeath;
//         }
//
//         private void OnDeath()
//         {
//             _particleSystem.Play();
//         }
//     }
// }