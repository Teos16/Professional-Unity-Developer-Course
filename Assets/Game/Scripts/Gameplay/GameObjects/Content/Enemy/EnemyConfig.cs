using Fusion;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Enemy",order = 0)]
    public sealed class EnemyConfig : ScriptableObject
    {
        [SerializeField] private NetworkPrefabRef _prefab;
        [SerializeField] private int _maxHealth = 3;
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _attackRadius = 0.5f;
        [SerializeField] private float _movementSpeed = 1f;
        [SerializeField] private Vector2Int _reward;
        
        public NetworkPrefabRef Prefab => _prefab;
        public int Damage => _damage;
        public float AttackCooldown => _attackCooldown;
        public float AttackRadius => _attackRadius;
        public Vector2Int Reward => _reward;
        public int MaxHealth => _maxHealth;
        public float MovementSpeed => _movementSpeed;
    }
}