using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Components/Move")]
    public sealed class MoveConfig : ScriptableObject
    {
        [SerializeField] private float _speed = 1;
        [SerializeField] private float _angularSpeed = 720;

        public float Speed => _speed;
        public float AngularSpeed => _angularSpeed;
    }
}
