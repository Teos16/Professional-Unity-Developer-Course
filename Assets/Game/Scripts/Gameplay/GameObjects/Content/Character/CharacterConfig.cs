using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Character",order = 1)]
    public sealed class CharacterConfig : ScriptableObject
    {
        [SerializeField] private int _maxHealth = 3;
        [SerializeField] private float _attackCooldown = 2f;
        [SerializeField] private float _attackRange = 8f;
        [SerializeField] private float _movementSpeed = 1f;
        
        public float AttackCooldown => _attackCooldown;
        public float AttackRange => _attackRange;
        public int MaxHealth => _maxHealth;
        public float MovementSpeed => _movementSpeed;
    }
}