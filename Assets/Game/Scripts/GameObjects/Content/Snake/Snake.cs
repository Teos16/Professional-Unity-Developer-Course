using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(HealthComponent), typeof(PhysicsComponent), typeof(GroundedComponent))]
    [RequireComponent(typeof(FollowTargetComponent), typeof(MoveComponent), typeof(MoveTransformComponent))]
    [RequireComponent(typeof(OverlapDetectTargetComponent), typeof(TargetComponent), typeof(AttackTargetComponent))]
    [RequireComponent(typeof(PushRigidbodyComponent), typeof(ExtraGravityComponent))]
    public sealed class Snake : MonoBehaviour, 
        FollowTargetComponent.ICondition,
        MoveComponent.IAction, 
        MoveComponent.ICondition, 
        OverlapDetectTargetComponent.ICondition,
        AttackTargetComponent.ICondition,
        AttackTargetComponent.IAction,
        PushRigidbodyComponent.ICondition
    {
        [SerializeField] private AttackConfig _attackConfig;
        [SerializeField] private float _followRange = 5f;
        [SerializeField] private float _attackRange = 1f;
        [SerializeField] private Transform _attackPoint;

        private HealthComponent _healthComponent;
        private PhysicsComponent _physicsComponent;
        private GroundedComponent _groundedComponent;
        private FollowTargetComponent _followTargetComponent;
        private MoveComponent _moveComponent;
        private MoveTransformComponent _moveTransformComponent;
        private OverlapDetectTargetComponent _overlapDetectTargetComponent;
        private TargetComponent _targetComponent;
        private AttackTargetComponent _attackTargetComponent;
        private PushRigidbodyComponent _pushRigidbodyComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _physicsComponent = GetComponent<PhysicsComponent>();
            _groundedComponent = GetComponent<GroundedComponent>();
            _followTargetComponent = GetComponent<FollowTargetComponent>();
            _moveComponent = GetComponent<MoveComponent>();
            _moveTransformComponent = GetComponent<MoveTransformComponent>();
            _overlapDetectTargetComponent = GetComponent<OverlapDetectTargetComponent>();
            _targetComponent = GetComponent<TargetComponent>();
            _attackTargetComponent = GetComponent<AttackTargetComponent>();
            _pushRigidbodyComponent = GetComponent<PushRigidbodyComponent>();

            _followTargetComponent.SetCondition(this);
            _moveComponent.SetCondition(this);
            _moveComponent.SetAction(this);
            _overlapDetectTargetComponent.SetCondition(this);
            _attackTargetComponent.SetCondition(this);
            _attackTargetComponent.SetAction(this);
            _pushRigidbodyComponent.SetCondition(this);
        }

        private void OnEnable() => _healthComponent.OnDied += _physicsComponent.TurnOffPhysics;

        private void OnDisable() => _healthComponent.OnDied -= _physicsComponent.TurnOffPhysics;

        bool FollowTargetComponent.ICondition.Evaluate() =>
            _healthComponent.IsAlive
            && _groundedComponent.IsGrounded
            && _targetComponent.Target != null
            && Vector2.Distance(transform.position, _targetComponent.Target.transform.position) <= _followRange;

        bool MoveComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;

        void MoveComponent.IAction.Invoke(Vector2 direction, float deltaTime) => _moveTransformComponent.
            Move(direction, deltaTime);

        bool OverlapDetectTargetComponent.ICondition.EvaluateTarget(GameObject target) =>
            target.TryGetComponent(out Character character)
            && target.TryGetComponent(out HealthComponent health)
            && health.IsAlive
            && target.TryGetComponent(out Rigidbody2D rb);

        bool AttackTargetComponent.ICondition.Evaluate() =>
            _healthComponent.IsAlive 
            && _groundedComponent.IsGrounded
            && _targetComponent.Target != null
            && Vector2.Distance(_attackPoint.transform.position, _targetComponent.Target.transform.position) 
            <= _attackRange;
        
        void AttackTargetComponent.IAction.Invoke(GameObject target)
        {
            _pushRigidbodyComponent.TryPush(target.GetComponent<Rigidbody2D>(), _attackConfig.PushConfig, 
                _attackPoint.transform.position);
            target.GetComponent<HealthComponent>().TakeDamage(_attackConfig.Damage);
            _targetComponent.Target = null;
        }
        
        bool PushRigidbodyComponent.ICondition.Evaluate() => _healthComponent.IsAlive && _groundedComponent.IsGrounded;
    }
}