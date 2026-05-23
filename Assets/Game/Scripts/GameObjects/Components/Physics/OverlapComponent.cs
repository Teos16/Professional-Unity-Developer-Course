using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    public sealed class OverlapComponent : MonoBehaviour
    {
        [Title("Area")]
        [SerializeField] private Transform _point;
        [SerializeField] private Vector2 _size = Vector2.one;
        [SerializeField] private Vector2 _offset = Vector2.zero;
        [SerializeField] private int _maxCount = 10;

        [Title("Filter")]
        [SerializeField] private ContactFilter2D _contactFilter;
        
        private Collider2D[] _results;
        private Collider2D[] _filteredResults;
        
        private bool _wasDetected;
        private float _timer;
        
        private void Awake() => _results = new Collider2D[_maxCount];

        public int Detect(out Collider2D[] results)
        {
            int count = Physics2D.OverlapBox((Vector2)_point.position + _offset, _size, 0f, _contactFilter, _results);
            results = _results;
            return count;
        }
        
        public int Detect(out Collider2D[] results, params Type[] componentTypes)
        {
            int count = Physics2D.OverlapBox((Vector2)_point.position + _offset, _size, 0f, _contactFilter, _results);
            int filteredCount = 0;

            for (int i = 0; i < count; i++)
            {
                Collider2D col = _results[i];
            
                for (int j = 0; j < componentTypes.Length; j++)
                {
                    if (col.TryGetComponent(componentTypes[j], out _))
                    {
                        _filteredResults[filteredCount] = col;
                        filteredCount++;
                        break; 
                    }
                }
            }

            results = _filteredResults;
            return filteredCount;
        }
        
        private void OnDrawGizmos()
        {
            if (_point == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube((Vector2)_point.position + _offset, new Vector3(_size.x, _size.y, 0));
        }
    }
}