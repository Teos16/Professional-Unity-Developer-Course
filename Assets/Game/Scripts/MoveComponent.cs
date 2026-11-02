using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class MoveComponent : NetworkBehaviour
    {
        public interface ICondition
        {
            public bool IsMet();
        }
        
        [SerializeField]
        private float _moveSpeed = 5;

        [SerializeField]
        private float _speedMultiplier = 2;

        [SerializeField]
        private float _angularSpeed = 720;
        
        private ICondition _condition;
        
        public void SetCondition(ICondition condition)
        {
            _condition = condition;
        }

        public void Move(Vector3 direction, bool isSprint)
        {
            if (direction == Vector3.zero || (_condition != null && !_condition.IsMet()))
                return;

            float deltaTime = this.Runner.DeltaTime;
            this.UpdateRotation(direction, deltaTime);
            this.UpdatePosition(direction, isSprint, deltaTime);
        }

        private void UpdateRotation(Vector3 direction, float deltaTime)
        {
            Quaternion current = this.transform.rotation;
            Quaternion target = Quaternion.LookRotation(direction, Vector3.up);
            this.transform.rotation = Quaternion.RotateTowards(
                current, target, _angularSpeed * deltaTime);
        }

        private void UpdatePosition(Vector3 direction, bool isSprint, float deltaTime)
        {
            float moveSpeed = _moveSpeed;
            if (isSprint)
                moveSpeed *= _speedMultiplier;

            this.transform.position += direction * deltaTime * moveSpeed;
        }
    }
}