using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PatrolComponent), typeof(MoveRequestComponent), typeof(MoveTransformComponent))]
    [RequireComponent(typeof(LookComponent), typeof(HealthComponent), typeof(CollisionComponent))]
    [RequireComponent(typeof(PushRigidbodyComponent), typeof(ExtraGravityComponent), typeof(AttackComponent))]
    [RequireComponent(typeof(GroundedComponent), typeof(OnDeathComponent))]
    public sealed class Spider : MonoBehaviour, 
        MoveRequestComponent.IAction, 
        MoveRequestComponent.ICondition, 
        PushRigidbodyComponent.ICondition,
        //AttackComponent.ICondition,
        PatrolComponent.ICondition
    {
        private PatrolComponent _patrolComponent;
        private MoveRequestComponent _moveRequestComponent;
        private MoveTransformComponent _moveTransformComponent;
        private LookComponent _lookComponent;
        private HealthComponent _healthComponent;
        private CollisionComponent _collisionComponent;
        private PushRigidbodyComponent _pushRigidbodyComponent;
        private ExtraGravityComponent _extraGravityComponent;
        private GroundedComponent _groundedComponent;
        private OnDeathComponent _onDeathComponent;
        private AttackComponent _attackComponent;
        
        private void Awake()
        {
            _patrolComponent = GetComponent<PatrolComponent>();
            _moveRequestComponent = GetComponent<MoveRequestComponent>();
            _moveTransformComponent = GetComponent<MoveTransformComponent>();
            _lookComponent = GetComponent<LookComponent>();
            _healthComponent = GetComponent<HealthComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _pushRigidbodyComponent = GetComponent<PushRigidbodyComponent>();
            _extraGravityComponent = GetComponent<ExtraGravityComponent>();
            _onDeathComponent = GetComponent<OnDeathComponent>();
            _attackComponent = GetComponent<AttackComponent>();
            
            _moveRequestComponent.SetCondition(this);
            _moveRequestComponent.SetAction(this);
            _pushRigidbodyComponent.SetCondition(this);
            _attackComponent.SetConditions(EvaluateAttackTarget, EvaluateOtherAttackConditions);
            _patrolComponent.SetCondition(this);
        }

        private void OnEnable()
        {
            _healthComponent.OnDied += _onDeathComponent.TurnOffPhysics;
            _collisionComponent.OnEntered += _attackComponent.Attack;
        }

        private void OnDisable()
        {
            _healthComponent.OnDied -= _onDeathComponent.TurnOffPhysics;
            _collisionComponent.OnEntered -= _attackComponent.Attack;
        }

        bool MoveRequestComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        void MoveRequestComponent.IAction.Invoke(Vector2 direction)
        {
            _moveTransformComponent.Move(direction);
            _lookComponent.Look(direction.x);
        }

        bool PushRigidbodyComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;
        
        bool PatrolComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        private bool EvaluateAttackTarget(GameObject target) => 
            target.TryGetComponent(out HealthComponent enemyHealth) && enemyHealth.IsAlive;

        private bool EvaluateOtherAttackConditions() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;
    }
}