using Fusion;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public sealed class RewardComponent : NetworkBehaviour
    {
        [SerializeField] private RewardConfig _config;

        public int Roll() => Random.Range(_config.Range.x, _config.Range.y + 1);
    }
}
