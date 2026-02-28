using System;
using UnityEngine;

namespace Game.Ships
{
    public sealed class MoveComponent : MonoBehaviour
    {
        public Vector3 MoveDirection { get; private set; }
            
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private ShipConfig _config;

        private CompositeCondition _moveConditions = new();

        private void FixedUpdate()
        {
            if(!_moveConditions.Evaluate())
                return;
            
            Vector2 direction = MoveDirection;
            Vector2 newPosition = _rigidbody.position + direction * (_config.MoveSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(newPosition);
        }

        public void SetConfig(ShipConfig config) => _config = config;

        public void AddMoveCondition(Func<bool> condition) => 
            _moveConditions.AddCondition(new InlineCondition(condition));

        public void MoveStep(Vector2 direction) => MoveDirection = direction;
    }
}