using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Enemy : NetworkBehaviour, MoveComponent.ICondition, MeleeAttackComponent.ICondition
    {
        [SerializeField] private EnemyConfig _config;
        
        private HealthComponent _healthComponent;
        private MoveComponent _moveComponent;
        private MeleeAttackComponent _meleeAttackComponent;
        private RewardComponent _rewardComponent;

        public override void Spawned()
        {
            _healthComponent = GetBehaviour<HealthComponent>();
            _rewardComponent = GetBehaviour<RewardComponent>();
            _moveComponent = GetBehaviour<MoveComponent>();
            _meleeAttackComponent = GetBehaviour<MeleeAttackComponent>();
            
            _moveComponent.SetCondition(this);
            _meleeAttackComponent.SetCondition(this);
            
            _healthComponent.Initialize(_config.MaxHealth);
            _meleeAttackComponent.Initialize(_config.AttackRadius, _config.AttackCooldown, _config.Damage);
            _moveComponent.Initialize(_config.MovementSpeed);
            _rewardComponent.Initialize(_config.Reward);
        }

        bool MoveComponent.ICondition.IsMet() => _healthComponent.IsAlive;

        bool MeleeAttackComponent.ICondition.IsMet() => _healthComponent.IsAlive;
    }
}