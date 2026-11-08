using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class AttackAnimationView : NetworkBehaviour
    {
        private static readonly int Fire = Animator.StringToHash(nameof(Fire));

        [SerializeField] private Animator _animator;
        
        private RangeAttackComponent _rangeAttack;
        private int _lastAttackCount;

        public override void Spawned()
        {
            _rangeAttack = this.Object.GetBehaviour<RangeAttackComponent>();
            _lastAttackCount = _rangeAttack.AttackCount;
        }

        public override void Render()
        {
            if (_rangeAttack.AttackCount == _lastAttackCount)
                return;

            _lastAttackCount = _rangeAttack.AttackCount;
            _animator.SetTrigger(Fire);
        }
    }
}