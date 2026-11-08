using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Components/Health")]
    public sealed class HealthConfig : ScriptableObject
    {
        [SerializeField] private int _maxHealth = 3;

        public int MaxHealth => _maxHealth;
    }
}
