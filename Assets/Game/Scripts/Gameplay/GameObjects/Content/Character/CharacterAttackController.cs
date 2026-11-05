using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class CharacterAttackController : NetworkBehaviour
    {
        [SerializeField] private TargetFinderComponent _targetFinder;
        [SerializeField] private RangeAttackComponent _rangeAttack;

        public override void FixedUpdateNetwork()
        {
            if (_targetFinder.TryFindTarget(out Collider target))
                _rangeAttack.Attack(target.bounds.center);
        }
    }
}