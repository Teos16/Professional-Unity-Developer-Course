using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class AutoAttackController : NetworkBehaviour
    {
        private TargetFinderComponent _targetFinder;
        private RangeAttackComponent _rangeAttack;

        public override void Spawned()
        {
            _targetFinder = GetBehaviour<TargetFinderComponent>();
            _rangeAttack = GetBehaviour<RangeAttackComponent>();
        }

        public override void FixedUpdateNetwork()
        {
            if (_targetFinder.TryFindTarget(out Collider target))
                _rangeAttack.Attack(target.bounds.center);
        }
    }
}
