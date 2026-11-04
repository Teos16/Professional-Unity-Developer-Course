using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Character : NetworkBehaviour, MoveComponent.ICondition
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private CharacterConfig _config;

        public override void Spawned()
        {
            _moveComponent.SetCondition(this);
            _healthComponent.Initialize(_config.MaxHealth);
            _moveComponent.Initialize(_config.MovementSpeed);
        }

        bool MoveComponent.ICondition.IsMet() => _healthComponent.IsAlive;
    }
}