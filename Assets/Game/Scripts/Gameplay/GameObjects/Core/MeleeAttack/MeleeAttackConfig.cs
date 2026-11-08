using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Components/MeleeAttack")]
    public sealed class MeleeAttackConfig : ScriptableObject
    {
        [SerializeField] private float _radius = 1;
        [SerializeField] private float _cooldown = 1;
        [SerializeField] private int _damage = 1;

        public float Radius => _radius;
        public float Cooldown => _cooldown;
        public int Damage => _damage;
    }
}
