using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(HealthComponent), typeof(GroundedComponent), typeof(MoveTransformComponent))]
    [RequireComponent(typeof(LookComponent), typeof(MoveRequestComponent), typeof(JumpRequestComponent))]
    [RequireComponent(typeof(CooldownComponent), typeof(JumpRigidbodyComponent), typeof(ExtraGravityComponent))]
    [RequireComponent(typeof(OnDeathComponent))]
    public sealed class Character : MonoBehaviour, 
        MoveRequestComponent.IAction, 
        MoveRequestComponent.ICondition,
        JumpRequestComponent.IAction,
        JumpRequestComponent.ICondition,
        IStaff
    {
        private GameObject _staff;
        private HealthComponent _healthComponent;
        private OnDeathComponent _onDeathComponent;
        private MoveTransformComponent _moveTransformComponent;
        private MoveRequestComponent _moveRequestComponent;
        private LookComponent _lookComponent;
        private GroundedComponent _groundedComponent;
        private JumpRigidbodyComponent _jumpRigidbodyComponent;
        private JumpRequestComponent _jumpRequestComponent;
        private ExtraGravityComponent _extraGravityComponent;
        private CooldownComponent _jumpCooldownComponent;
        
        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _onDeathComponent = GetComponent<OnDeathComponent>();
            _moveTransformComponent = GetComponent<MoveTransformComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _jumpRigidbodyComponent = GetComponent<JumpRigidbodyComponent>();
            _jumpRequestComponent = GetComponent<JumpRequestComponent>();
            _extraGravityComponent = GetComponent<ExtraGravityComponent>();
            _jumpCooldownComponent = GetComponent<CooldownComponent>();
            
            _staff = GetComponentInChildren<Staff>().gameObject;
            
            _moveRequestComponent.SetAction(this);
            _moveRequestComponent.SetCondition(this);
            _jumpRequestComponent.SetAction(this);
            _jumpRequestComponent.SetCondition(this);
        }

        private void OnEnable() => _healthComponent.OnDied += _onDeathComponent.TurnOffPhysics;
        
        private void OnDisable() => _healthComponent.OnDied -= _onDeathComponent.TurnOffPhysics;

        void MoveRequestComponent.IAction.Invoke(Vector2 direction)
        {
            _moveTransformComponent.Move(direction);
            _lookComponent.Look(direction.x);
        }

        bool MoveRequestComponent.ICondition.Evaluate() => _healthComponent.IsAlive;

        bool JumpRequestComponent.ICondition.Evaluate() => 
            _groundedComponent.IsGrounded && _healthComponent.IsAlive && _jumpCooldownComponent.IsExpired;

        void JumpRequestComponent.IAction.Invoke()
        {
            _jumpRigidbodyComponent.Jump();
            _jumpCooldownComponent.Reset();
        }

        void IStaff.Push()
        {
            if(_staff != null && _healthComponent.IsAlive && _groundedComponent.IsGrounded) 
                _staff.GetComponent<Staff>().Push();
        }

        void IStaff.Toss()
        {
            if(_staff != null && _healthComponent.IsAlive && _groundedComponent.IsGrounded) 
                _staff.GetComponent<Staff>().Toss();
        }
    }
}