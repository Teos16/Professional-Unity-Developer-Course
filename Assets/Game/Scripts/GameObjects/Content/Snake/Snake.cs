using Sirenix.OdinInspector;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(HealthComponent), typeof(MoveTransformComponent), typeof(MoveRequestComponent))]
    [RequireComponent(typeof(LookComponent), typeof(ExtraGravityComponent), typeof(GroundedComponent))]
    [RequireComponent(typeof(PushRigidbodyComponent), typeof(FollowComponent), typeof(OnDeathComponent))]
    public sealed class Snake : MonoBehaviour, 
        MoveRequestComponent.IAction, 
        MoveRequestComponent.ICondition, 
        PushRigidbodyComponent.ICondition,
        FollowComponent.ICondition
        //AttackComponent.ICondition
    {
        [SerializeField, Title("Attack Parameters")] private AttackComponent _attackComponent;
        [SerializeField] private TriggerComponent _attackTriggerComponent;
        [SerializeField] private PushRigidbodyComponent _pushRigidbodyComponent;

        private HealthComponent _healthComponent;
        private LookComponent _lookComponent;
        private ExtraGravityComponent _extraGravityComponent;
        private GroundedComponent _groundedComponent;
        private MoveTransformComponent _moveTransformComponent;
        private MoveRequestComponent _moveRequestComponent;
        private OnDeathComponent _onDeathComponent;
        private FollowComponent _followComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _moveTransformComponent = GetComponent<MoveTransformComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _extraGravityComponent = GetComponent<ExtraGravityComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _followComponent = GetComponent<FollowComponent>();
            _onDeathComponent = GetComponent<OnDeathComponent>();
            
            _moveRequestComponent.SetCondition(this);
            _moveRequestComponent.SetAction(this);
            _pushRigidbodyComponent.SetCondition(this);
            _followComponent.SetCondition(this);
            _attackComponent.SetConditions(EvaluateAttackTarget, EvaluateOtherAttackConditions);
        }

        private void OnEnable()
        {
            _healthComponent.OnDied += _onDeathComponent.TurnOffPhysics;
            _attackTriggerComponent.OnEntered += _attackComponent.Attack;
        }

        private void OnDisable()
        {
            _healthComponent.OnDied -= _onDeathComponent.TurnOffPhysics;
            _attackTriggerComponent.OnEntered -= _attackComponent.Attack;
        }

        void MoveRequestComponent.IAction.Invoke(Vector2 direction) => _moveTransformComponent.Move(direction);

        bool MoveRequestComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        bool PushRigidbodyComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        bool FollowComponent.ICondition.EvaluateTarget(GameObject target) =>
            target.TryGetComponent(out Character character)
            && target.TryGetComponent(out HealthComponent health)
            && health.IsAlive;

        bool FollowComponent.ICondition.EvaluateOtherConditions() => 
            _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        private bool EvaluateOtherAttackConditions() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        private bool EvaluateAttackTarget(GameObject target) =>
            target.TryGetComponent(out Character character)
            && target.TryGetComponent(out HealthComponent health)
            && health.IsAlive;
    }
}