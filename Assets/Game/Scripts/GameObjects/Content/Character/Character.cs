using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(HealthComponent), typeof(PhysicsComponent), typeof(MoveComponent))]
    [RequireComponent(typeof(MoveTransformComponent), typeof(LookComponent), typeof(JumpRigidbodyComponent))]
    [RequireComponent(typeof(JumpRequestComponent), typeof(CooldownComponent), typeof(GroundedComponent))]
    [RequireComponent(typeof(ExtraGravityComponent))]
    public sealed class Character : MonoBehaviour, 
        MoveComponent.IAction, 
        MoveComponent.ICondition,
        JumpRequestComponent.IAction,
        JumpRequestComponent.ICondition,
        IPushComponent,
        ITossComponent
    {
        private HealthComponent _healthComponent;
        private PhysicsComponent _physicsComponent;
        private MoveComponent _moveComponent;
        private MoveTransformComponent _moveTransformComponent;
        private LookComponent _lookComponent;
        private JumpRigidbodyComponent _jumpRigidbodyComponent;
        private JumpRequestComponent _jumpRequestComponent;
        private CooldownComponent _jumpCooldownComponent;
        private GroundedComponent _groundedComponent;

        private GameObject _staff;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _physicsComponent = GetComponent<PhysicsComponent>();
            _moveComponent = GetComponent<MoveComponent>();
            _moveTransformComponent = GetComponent<MoveTransformComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _jumpRigidbodyComponent = GetComponent<JumpRigidbodyComponent>();
            _jumpRequestComponent = GetComponent<JumpRequestComponent>();
            _jumpCooldownComponent = GetComponent<CooldownComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();

            _staff = GetComponentInChildren<Staff>().gameObject;
            
            _moveComponent.SetAction(this);
            _moveComponent.SetCondition(this);
            _jumpRequestComponent.SetAction(this);
            _jumpRequestComponent.SetCondition(this);
        }

        private void OnEnable() => _healthComponent.OnDied += _physicsComponent.TurnOffPhysics;
        
        private void OnDisable() => _healthComponent.OnDied -= _physicsComponent.TurnOffPhysics;

        void MoveComponent.IAction.Invoke(Vector2 direction, float deltaTime)
        {
            _moveTransformComponent.Move(direction, deltaTime);
            _lookComponent.Look(direction.x);
        }

        bool MoveComponent.ICondition.Evaluate() => _healthComponent.IsAlive;

        bool JumpRequestComponent.ICondition.Evaluate() => 
            _groundedComponent.IsGrounded && _healthComponent.IsAlive && _jumpCooldownComponent.IsExpired;

        void JumpRequestComponent.IAction.Invoke()
        {
            _jumpRigidbodyComponent.Jump();
            _jumpCooldownComponent.Reset();
        }

        void IPushComponent.Push()
        {
            if(_staff != null && _healthComponent.IsAlive && _groundedComponent.IsGrounded) 
                _staff.GetComponent<Staff>().Push();
        }

        void ITossComponent.Toss()
        {
            if(_staff != null && _healthComponent.IsAlive && _groundedComponent.IsGrounded) 
                _staff.GetComponent<Staff>().Toss();
        }
    }
}