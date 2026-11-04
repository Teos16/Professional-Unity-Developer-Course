using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Enemy : NetworkBehaviour, MoveComponent.ICondition, MeleeAttackComponent.ICondition
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private MeleeAttackComponent _meleeAttackComponent;
        [SerializeField] private EnemyConfig _config;

        public override void Spawned()
        {
            _healthComponent.Initialize(_config.MaxHealth);
            _meleeAttackComponent.Initialize(_config.AttackRadius, _config.AttackCooldown, _config.Damage);
            _moveComponent.Initialize(_config.MovementSpeed);
            _moveComponent.SetCondition(this);
            _meleeAttackComponent.SetCondition(this);
        }

        bool MoveComponent.ICondition.IsMet() => _healthComponent.IsAlive;

        bool MeleeAttackComponent.ICondition.IsMet() => _healthComponent.IsAlive;
    }
}