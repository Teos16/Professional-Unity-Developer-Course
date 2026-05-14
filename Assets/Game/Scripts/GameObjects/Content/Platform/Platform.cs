using UnityEngine;

namespace Game.Scripts.GameObjects.Content.Platform
{
    [RequireComponent(typeof(PatrolComponent), typeof(MoveRequestComponent), typeof(MoveTransformComponent))]
    [RequireComponent(typeof(ParentingComponent), typeof(CollisionComponent))]
    public sealed class Platform : MonoBehaviour, MoveRequestComponent.ICondition, MoveRequestComponent.IAction
    {
        private PatrolComponent _patrolComponent;
        private MoveRequestComponent _moveRequestComponent;
        private MoveTransformComponent _moveTransformComponent;
        private ParentingComponent _parentingComponent;
        private CollisionComponent _collisionComponent;

        private void Awake()
        {
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveTransformComponent = GetComponent<MoveTransformComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            
            _moveRequestComponent.SetCondition(this);
            _moveRequestComponent.SetAction(this);
        }

        bool MoveRequestComponent.ICondition.Evaluate() => true;

        void MoveRequestComponent.IAction.Invoke(Vector2 direction) => _moveTransformComponent.Move(direction);
    }
}