using System;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(HealthComponent), typeof(PhysicsComponent), typeof(PatrolComponent))]
    [RequireComponent(typeof(MoveComponent), typeof(MoveTransformComponent), typeof(GroundedComponent))]
    [RequireComponent(typeof(CollisionComponent), typeof(PushRigidbodyComponent), typeof(ExtraGravityComponent))]
    public sealed class Spider : MonoBehaviour, 
        PatrolComponent.ICondition,
        MoveComponent.ICondition, 
        MoveComponent.IAction, 
        PushRigidbodyComponent.ICondition
    {
        [SerializeField] private AttackConfig _attackConfig;

        private HealthComponent _healthComponent;
        private PhysicsComponent _physicsComponent;
        private PatrolComponent _patrolComponent;
        private MoveComponent _moveComponent;
        private MoveTransformComponent _moveTransformComponent;
        private GroundedComponent _groundedComponent;
        private CollisionComponent _collisionComponent;
        private PushRigidbodyComponent _pushRigidbodyComponent;
        
        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _physicsComponent = GetComponent<PhysicsComponent>();
            _patrolComponent = GetComponent<PatrolComponent>();
            _moveComponent = GetComponent<MoveComponent>();
            _moveTransformComponent = GetComponent<MoveTransformComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            _pushRigidbodyComponent = GetComponent<PushRigidbodyComponent>();

            _patrolComponent.SetCondition(this);
            _moveComponent.SetCondition(this);
            _moveComponent.SetAction(this);
            _pushRigidbodyComponent.SetCondition(this);
        }

        private void OnEnable()
        {
            _healthComponent.OnDied += _physicsComponent.TurnOffPhysics;
            _collisionComponent.OnEntered += Attack;
        }
        
        private void OnDisable()
        {
            _healthComponent.OnDied -= _physicsComponent.TurnOffPhysics;
            _collisionComponent.OnEntered -= Attack;
        }

        bool PatrolComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;
        
        bool MoveComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;
        
        void MoveComponent.IAction.Invoke(Vector2 direction, float deltaTime) => 
            _moveTransformComponent.Move(direction, deltaTime);

        private void Attack(Collision2D col)
        {
            GameObject target = col.gameObject;
            HealthComponent targetHealth = target.GetComponent<HealthComponent>();
            
            if (!col.rigidbody || !targetHealth || !targetHealth.IsAlive) 
                return;
            
            _pushRigidbodyComponent.TryPush(col.rigidbody, _attackConfig.PushConfig, transform.position);
            targetHealth.TakeDamage(_attackConfig.Damage);
        }

        bool PushRigidbodyComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;
    }
}