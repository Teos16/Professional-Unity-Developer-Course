using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Archer : NetworkBehaviour,
        RangeAttackComponent.ICondition,
        TargetFinderComponent.ICondition
    {
        [SerializeField] private float _lifetime = 15;

        [Networked] private TickTimer _lifeTimer { get; set; }

        public override void Spawned()
        {
            GetBehaviour<RangeAttackComponent>().SetCondition(this);
            GetBehaviour<TargetFinderComponent>().SetCondition(this);

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
