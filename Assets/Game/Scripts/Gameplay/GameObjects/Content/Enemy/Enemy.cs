using Fusion;

namespace Game
{
    public sealed class Enemy : NetworkBehaviour,
        MoveComponent.ICondition,
        MeleeAttackComponent.ICondition
    {
        private HealthComponent _healthComponent;

        public override void Spawned()
        {
            _healthComponent = GetBehaviour<HealthComponent>();

            GetBehaviour<MoveComponent>().SetCondition(this);
            GetBehaviour<MeleeAttackComponent>().SetCondition(this);
        }

        bool MoveComponent.ICondition.IsMet() => _healthComponent.IsAlive;

        bool MeleeAttackComponent.ICondition.IsMet() => _healthComponent.IsAlive;
    }
}
