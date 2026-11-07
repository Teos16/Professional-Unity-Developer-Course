using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Character : NetworkBehaviour, 
        MoveComponent.ICondition, 
        RangeAttackComponent.ICondition, 
        TargetFinderComponent.ICondition
    {
        [SerializeField] private CharacterConfig _config;
        
        private HealthComponent _healthComponent;
        private MoveComponent _moveComponent;
        private TargetFinderComponent _targetFinder;
        private RangeAttackComponent _rangeAttack;

        public override void Spawned()
        {
            _healthComponent = GetBehaviour<HealthComponent>();
            _moveComponent = GetBehaviour<MoveComponent>();
            _targetFinder = GetBehaviour<TargetFinderComponent>();
            _rangeAttack = GetBehaviour<RangeAttackComponent>();
            
            _moveComponent.SetCondition(this);
            _rangeAttack.SetCondition(this);
            _targetFinder.SetCondition(this);
            
            _healthComponent.Initialize(_config.MaxHealth);
            _moveComponent.Initialize(_config.MovementSpeed);
            _rangeAttack.Initialize(_config.AttackCooldown);
            _targetFinder.Initialize(_config.AttackRange);
        }

        bool MoveComponent.ICondition.IsMet() => _healthComponent.IsAlive;

        bool RangeAttackComponent.ICondition.IsMet() => _healthComponent.IsAlive;

        bool TargetFinderComponent.ICondition.IsMet() => _healthComponent.IsAlive;
    }
}