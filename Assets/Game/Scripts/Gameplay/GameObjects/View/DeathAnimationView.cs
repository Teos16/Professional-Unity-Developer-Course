using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class DeathAnimationView : NetworkBehaviour
    {
        private static readonly int IsDead = Animator.StringToHash(nameof(IsDead));

        [SerializeField] private Animator _animator;
        
        private HealthComponent _health;

        public override void Spawned() => _health = this.Object.GetBehaviour<HealthComponent>();
        
        public override void Render() => _animator.SetBool(IsDead, _health.IsDead);
    }
}