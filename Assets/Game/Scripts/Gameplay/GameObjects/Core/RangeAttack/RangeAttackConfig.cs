using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Components/RangeAttack")]
    public sealed class RangeAttackConfig : ScriptableObject
    {
        [SerializeField] private float _cooldown = 2;

        public float Cooldown => _cooldown;
    }
}
