using Fusion;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Trap", order = 3)]
    public sealed class TrapConfig : ScriptableObject
    {
        [SerializeField] private NetworkPrefabRef _prefab;
        [SerializeField] private int _cost;

        public NetworkPrefabRef Prefab => _prefab;
        public int Cost => _cost;
    }
}