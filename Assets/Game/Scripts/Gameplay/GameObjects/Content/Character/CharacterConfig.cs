using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Character",order = 1)]
    public sealed class CharacterConfig : ScriptableObject
    {
        [SerializeField] private int _maxHealth = 3;
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _movementSpeed = 1f;
        
        public int Damage => _damage;
        public float AttackCooldown => _attackCooldown;
        public int MaxHealth => _maxHealth;
        public float MovementSpeed => _movementSpeed;
    }
}