using UnityEngine;

namespace Game.ShipRelated
{
    [CreateAssetMenu(menuName = "Game/ShipConfig", order = 0)]
    public sealed class ShipConfig : ScriptableObject
    {
        [Header("Core")]
        [field: SerializeField] public int Health { get; private set; } = 5;
        [field: SerializeField] public float MoveSpeed { get; private set; } = 5;
        [field: SerializeField] public float FireCooldown { get; private set; } = 1;
    }
}