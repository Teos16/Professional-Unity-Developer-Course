using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.ShipRelated
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [field:HideInInspector] [field:SerializeField] public Vector3 MoveDirection { get; private set; }
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private ShipConfig _config;

        private CompositeCondition _moveConditions = new();
        private Vector2? _currentDirection;

        private void FixedUpdate()
        {
            if(!_moveConditions.Evaluate())
                return;
            
            Vector2 direction = _currentDirection.Value;
            Vector2 newPosition = _rigidbody.position + direction * (_config.MoveSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(newPosition);
        }

        public void SetConfig(ShipConfig config) => _config = config;

        public void AddMoveCondition(Func<bool> condition) => 
            _moveConditions.AddCondition(new SingleCondition(condition));

        public void MoveStep(Vector2 direction)
        {
            if (direction.sqrMagnitude < 0.001f)
                _currentDirection = null;
            else
                _currentDirection = direction.normalized;
        }
    }
}