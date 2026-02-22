using UnityEngine;

namespace Game.Bullets
{
    [CreateAssetMenu(menuName = "Game/BulletConfig", order = 0)]

    public sealed class BulletConfig : ScriptableObject
    {
        [field: SerializeField] public TeamType TeamType { get; private set; } = TeamType.None;
        [field: SerializeField] public float BulletSpeed { get; private set; } = 2;
        [field: SerializeField] public int BulletDamage { get; private set; } = 2;
    }
}
