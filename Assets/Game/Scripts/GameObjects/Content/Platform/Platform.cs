using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PatrolComponent), typeof(MoveComponent), typeof(MoveTransformComponent))]
    [RequireComponent(typeof(ParentingComponent))]
    public sealed class Platform : MonoBehaviour, MoveComponent.ICondition, MoveComponent.IAction
    {
        private PatrolComponent _patrolComponent;
        private MoveComponent _moveComponent;
        private MoveTransformComponent _moveTransformComponent;
        private ParentingComponent _parentingComponent;

        private void Awake()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _moveTransformComponent = GetComponent<MoveTransformComponent>();
            
            _moveComponent.SetCondition(this);
            _moveComponent.SetAction(this);
        }

        bool MoveComponent.ICondition.Evaluate() => true;

        void MoveComponent.IAction.Invoke(Vector2 direction, float deltaTime) => _moveTransformComponent.Move(direction, 
            deltaTime);
    }
}