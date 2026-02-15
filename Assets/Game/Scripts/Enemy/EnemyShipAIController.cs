using Game.ShipRelated;
using UnityEngine;

namespace Game.Enemy
{
    [RequireComponent(typeof(Ship)), RequireComponent(typeof(AimedBulletCreator))]
    public sealed class EnemyShipAIController : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private Ship _target;
        [SerializeField] private float _stoppingDistance = 0.25f;
        
        public bool IsDead => !_ship.IsAlive();

        private Vector2 _destination;
        private Vector2 _moveDirection;

        private void FixedUpdate()
        {
            if (!AreTargetAndEnemyShipValid())
                return;

            Vector2 distance = _destination - (Vector2) this.transform.position;
            bool isNotReached = distance.sqrMagnitude > _stoppingDistance * _stoppingDistance;
            _moveDirection = isNotReached ? distance.normalized : Vector3.zero;

            if (isNotReached)
                _ship.MoveStep(_moveDirection);
            else
                _ship.Fire();
        }

        public void Initialize(Ship target, Vector2 spawnPosition, Vector2 destination)
        {
            _target ??= target;
            transform.position = spawnPosition;
            _destination = destination;
        }

        private bool AreTargetAndEnemyShipValid()
        {
            return _ship.IsAlive() && _target != null && _target.IsAlive();
        }
    }
}