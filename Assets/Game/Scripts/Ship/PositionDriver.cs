using System;
using UnityEngine;

namespace Game.ShipRelated
{
    [Serializable]
    public sealed class PositionDriver
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        private Vector2? _direction;
        private float _speed;

        public void SetSpeed(float speed) => _speed = speed;

        public void MoveStep(Vector2 direction) => _direction = direction;

        public void FixedUpdate()
        {
            if (!_direction.HasValue)
                return;

            Vector2 direction = _direction.Value;
            Vector2 newPosition = _rigidbody.position + direction * (_speed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(newPosition);
            _direction = null;
        }
    }
}