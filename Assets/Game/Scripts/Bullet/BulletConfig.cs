using UnityEngine;

namespace Game.Bullets
{
    [CreateAssetMenu(menuName = "Game/BulletConfig", order = 0)]

    public sealed class BulletConfig : ScriptableObject
    {
        [field: SerializeField] public TeamType Team { get; private set; } = TeamType.None;
        [field: SerializeField] public float Speed { get; private set; } = 2;
        [field: SerializeField] public int Damage { get; private set; } = 2;
    }
}
