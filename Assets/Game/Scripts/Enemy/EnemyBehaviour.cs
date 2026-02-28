using Game.Ships;
using UnityEngine;

namespace Game.Enemy
{
    [RequireComponent(typeof(Ship))]
    public sealed class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private Ship _target;
        [SerializeField] private float _stoppingDistance = 0.25f;

        private Vector2 _destination;
        private Vector2 _moveDirection;

        private void FixedUpdate()
        {
            if (!AreTargetAndEnemyShipValid())
            {
                _moveDirection = Vector3.zero;
                _ship.MoveStep(_moveDirection);
                return;
            }

            Vector2 distance = _destination - (Vector2) transform.position;
            bool isNotReached = distance.sqrMagnitude > _stoppingDistance * _stoppingDistance;
            _moveDirection = isNotReached ? distance.normalized : Vector3.zero;

            _ship.MoveStep(_moveDirection);
            if (!isNotReached)
                _ship.FireAt(_target.transform.position);
        }

        public void Construct(Ship target) => _target = target;
        
        public void SetDestination(Vector2 destination) => _destination = destination;
        
        public void SetPosition(Vector2 position) => transform.position = position;
        
        private bool AreTargetAndEnemyShipValid() => _ship.IsAlive() && _target != null && _target.IsAlive();
    }
}