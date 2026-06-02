using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class CharacterInstaller : SceneEntityInstaller
    {
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private MoveInstaller _moveInstaller;
        [SerializeField] private Const<float> _moveSpeed = 1;
        [SerializeField] private Const<float> _rotationSpeed = 720;
        [SerializeField] private RotateInstaller _rotateInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private FireInstaller _fireInstaller;
        [SerializeField] private Const<float> _armorPercent = 0.5f;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private SceneEntity _weapon;
        [SerializeField] private InteractorInstaller _interactorInstaller;
        [SerializeField] private TriggerEvents _triggerEvents;

        public override void Install(IEntity entity)
        {
            entity.AddCharacterTag();
            entity.AddTransform(transform);
            
            _transformInstaller.Install(entity);
            
            _moveInstaller.Install(entity);
            entity.GetMoveCondition().Add(_ => entity.IsAlive());
            entity.GetMoveCondition().Add(_ => entity.GetCurrentCar().Value == null);
            entity.GetMoveAction().Add(entity.MoveStep);
            entity.GetMoveAction().Add(entity.RotateStep);
            entity.AddMoveSpeed(_moveSpeed);
            
            _rotateInstaller.Install(entity);
            entity.GetRotateCondition().Add(_ => entity.IsAlive());
            entity.GetRotateAction().Add(entity.RotateStep);
            entity.AddRotationSpeed(_rotationSpeed);
            
            _healthInstaller.Install(entity);
            entity.AddTakeDamageAction(new InlineAction<int>(
                damage => entity.TakeDamageArmored(damage, _armorPercent)));
            
            _fireInstaller.Install(entity);
            entity.AddWeapon(new ReactiveVariable<IEntity>(_weapon));
            entity.GetFireCondition().Add(entity.IsAlive);
            entity.GetFireCondition().Add(() =>
            {
                IEntity weapon = entity.GetWeapon().Value;
                return weapon != null && weapon.GetFireCondition().Invoke();
            });
            entity.GetFireAction().Add(() => entity.GetWeapon().Value?.GetFireRequest().Invoke());
            
            _interactorInstaller.Install(entity);
            entity.AddTrigger(_triggerEvents);
            entity.AddCurrentCar(new Variable<CarController>());
        }
    }
}