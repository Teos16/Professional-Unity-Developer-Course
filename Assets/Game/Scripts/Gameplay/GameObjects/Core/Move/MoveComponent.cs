using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class MoveComponent : NetworkBehaviour
    {
        public interface ICondition
        {
            bool IsMet();
        }

        [SerializeField] private MoveConfig _config;

        [Networked] public NetworkBool IsMoving { get; private set; }

        private ICondition _condition;

        public void SetCondition(ICondition condition) => _condition = condition;

        public void Move(Vector3 direction)
        {
            IsMoving = direction != Vector3.zero && _condition != null && _condition.IsMet();
            if (!IsMoving)
                return;

            float deltaTime = Runner.DeltaTime;
            UpdateRotation(direction, deltaTime);
            UpdatePosition(direction, deltaTime);
        }

        private void UpdateRotation(Vector3 direction, float deltaTime)
        {
            Quaternion current = transform.rotation;
            Quaternion target = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(
                current, target, _config.AngularSpeed * deltaTime);
        }

        private void UpdatePosition(Vector3 direction, float deltaTime) =>
            transform.position += direction * deltaTime * _config.Speed;
    }
}
