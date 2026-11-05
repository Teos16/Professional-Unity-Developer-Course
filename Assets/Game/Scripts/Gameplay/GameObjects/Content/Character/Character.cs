using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Character : NetworkBehaviour, 
        MoveComponent.ICondition, 
        RangeAttackComponent.ICondition, 
        TargetFinderComponent.ICondition
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private TargetFinderComponent _targetFinder;
        [SerializeField] private RangeAttackComponent _rangeAttack;
        [SerializeField] private CharacterConfig _config;

        public override void Spawned()
        {
            _moveComponent.SetCondition(this);
            _rangeAttack.SetCondition(this);
            _targetFinder.SetCondition(this);
            _healthComponent.Initialize(_config.MaxHealth);
            _moveComponent.Initialize(_config.MovementSpeed);
            _rangeAttack.Initialize(_config.AttackCooldown);
        }

        bool MoveComponent.ICondition.IsMet() => _healthComponent.IsAlive;

        bool RangeAttackComponent.ICondition.IsMet() => _healthComponent.IsAlive;

        bool TargetFinderComponent.ICondition.IsMet() => _healthComponent.IsAlive;
    }
}