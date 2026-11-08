using Fusion;

namespace Game
{
    public sealed class Character : NetworkBehaviour,
        MoveComponent.ICondition,
        RangeAttackComponent.ICondition,
        TargetFinderComponent.ICondition
    {
        private HealthComponent _healthComponent;

        public override void Spawned()
        {
            _healthComponent = GetBehaviour<HealthComponent>();

            GetBehaviour<MoveComponent>().SetCondition(this);
            GetBehaviour<RangeAttackComponent>().SetCondition(this);
            GetBehaviour<TargetFinderComponent>().SetCondition(this);
        }

        bool MoveComponent.ICondition.IsMet() => _healthComponent.IsAlive;

        bool RangeAttackComponent.ICondition.IsMet() => _healthComponent.IsAlive;

        bool TargetFinderComponent.ICondition.IsMet() => _healthComponent.IsAlive;
    }
}
