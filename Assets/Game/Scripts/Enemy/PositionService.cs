using Modules.Utils;
using UnityEngine;

namespace Game.Enemy
{
    public sealed class PositionService : MonoBehaviour
    {
        [SerializeField] private Transform[] _positions;
        
        private int _currentIndex;
        
        private void Awake() => _positions.Shuffle();

        public Vector3 Next()
        {
            if (_currentIndex >= _positions.Length)
            {
                _positions.Shuffle();
                _currentIndex = 0;
            }

            return _positions[_currentIndex++].position;
        }
    }
}