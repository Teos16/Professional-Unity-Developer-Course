using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Archer : NetworkBehaviour,
        RangeAttackComponent.ICondition,
        TargetFinderComponent.ICondition
    {
        [SerializeField] private float _lifetime = 15;
        [SerializeField] private float _attackCooldown = 2;
        [SerializeField] private float _attackRange = 8;

        [Networked] private TickTimer _lifeTimer { get; set; }

        private RangeAttackComponent _rangeAttack;
        private TargetFinderComponent _targetFinder;

        public override void Spawned()
        {
            _rangeAttack = GetBehaviour<RangeAttackComponent>();
            _targetFinder = GetBehaviour<TargetFinderComponent>();

            _rangeAttack.SetCondition(this);
            _targetFinder.SetCondition(this);

            _rangeAttack.Initialize(_attackCooldown);
            _targetFinder.Initialize(_attackRange);

            if (HasStateAuthority)
                _lifeTimer = TickTimer.CreateFromSeconds(Runner, _lifetime);
        }

        public override void FixedUpdateNetwork()
        {
            if (HasStateAuthority && _lifeTimer.Expired(Runner))
                Runner.Despawn(Object);
        }

        bool RangeAttackComponent.ICondition.IsMet() => _lifeTimer.IsRunning;

        bool TargetFinderComponent.ICondition.IsMet() => _lifeTimer.IsRunning;
    }
}