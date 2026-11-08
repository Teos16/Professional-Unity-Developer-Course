using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Components/Reward")]
    public sealed class RewardConfig : ScriptableObject
    {
        [SerializeField] private Vector2Int _range = new(1, 5);

        public Vector2Int Range => _range;
    }
}
