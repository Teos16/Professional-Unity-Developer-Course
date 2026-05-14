using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(MoveRequestComponent))]
    public sealed class PatrolComponent : MonoBehaviour
    {
        public interface ICondition
        {
            bool Evaluate();
        }
        
        private const float EPSILON = 0.1f;
        
        [SerializeField] private Transform[] _waypoints;
        
        private MoveRequestComponent _moveRequestComponent;
        private ICondition _condition;

        private int _currentIndex;

        private void Awake()
        {
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            if (_waypoints.Length < 2) 
                Debug.LogError($"PatrolComponent of {gameObject.name}: Waypoints array is empty");
        }

        private void FixedUpdate()
        {
            if (_waypoints.Length < 2 && !_condition.Evaluate()) 
                return;
            Move();
        }
        
        public void SetCondition(ICondition condition) => _condition = condition;

        private void Move()
        {
            Vector2 target = _waypoints[_currentIndex].position;
            Vector2 direction = (target - (Vector2)transform.position).normalized;
            _moveRequestComponent.Move(direction);
            
            if (Vector2.Distance(transform.position, target) < EPSILON) 
                _currentIndex = (_currentIndex + 1) % _waypoints.Length;
        }
    }
}