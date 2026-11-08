using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Components/Explosion")]
    public sealed class ExplosionConfig : ScriptableObject
    {
        [SerializeField] private float _radius = 1;
        [SerializeField] private int _damage = 5;

        public float Radius => _radius;
        public int Damage => _damage;
    }
}
