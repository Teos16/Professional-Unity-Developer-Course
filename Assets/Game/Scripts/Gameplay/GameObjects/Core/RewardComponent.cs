using Fusion;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public sealed class RewardComponent : NetworkBehaviour
    {
        private Vector2Int _range;

        public void Initialize(Vector2Int range) => _range = range;

        public int Roll() => Random.Range(_range.x, _range.y + 1);
    }
}