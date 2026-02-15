using UnityEngine;

namespace Game.Enemy
{
    [CreateAssetMenu(menuName = "Game/EnemySpawnConfig", order = 0)]
    public sealed class EnemySpawnConfig : ScriptableObject
    {
        [field: Header("Spawn")]
        [field: SerializeField] public float MinSpawnCooldown { get; private set; } = 2;
        [field: SerializeField] public float MaxSpawnCooldown { get; private set; } = 3;
    }
}