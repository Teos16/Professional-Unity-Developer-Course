using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterInstaller : GameEntityInstaller
    {
        [SerializeField]
        private TransformInstaller _transformInstaller;

        [SerializeField]
        private CharacterMoveInstaller _moveInstaller;

        [SerializeField]
        private Const<float> _rotateSpeed = 720;

        [SerializeField]
        private RotateInstaller _rotateInstaller;

        [SerializeField]
        private HealthInstaller _healthInstaller;

        [SerializeField]
        private CharacterFireInstaller _fireInstaller;

        [SerializeField]
        private Const<float> _armorPercent = 0.5f;

        [SerializeField]
        private InteractorInstaller _interactorInstaller;

        [SerializeField]
        private TakeDamageInstaller _takeDamageInstaller;

        [SerializeField]
        private GameObject _gameObject;

        [SerializeField]
        private WeaponEntity _weapon;

        [SerializeField]
        private TriggerEvents _triggerEvents;

        [SerializeField]
        private ReactiveVariable<TeamType> _team;

        public override void Install(IGameEntity entity)
        {
            entity.AddCharacterTag();
            entity.AddTransform(transform);
            entity.AddTeam(_team);

            _transformInstaller.Install(entity);
            _healthInstaller.Install(entity);
            _moveInstaller.Install(entity);
            _fireInstaller.Install(entity);

            _interactorInstaller.Install(entity);

            entity.AddTrigger(_triggerEvents);
            entity.AddWeapon(new ReactiveVariable<IWeaponEntity>(_weapon));
            entity.AddRespawnAction(new InlineAction(entity.SetMaxHealth));

            InstallRotation(entity);
            InstallTakeDamage(entity);
            InstallTransport(entity);
        }

        private void InstallTransport(IGameEntity entity)
        {
            entity.AddCurrentTransport(new Variable<IGameEntity>());
        }

        private void InstallTakeDamage(IGameEntity entity)
        {
            _takeDamageInstaller.Install(entity);
            entity.GetTakeDamageAction().Add(damage => entity.ReduceHealthWithArmor(damage, _armorPercent));
        }

        private void InstallRotation(IGameEntity entity)
        {
            _rotateInstaller.Install(entity);
            entity.GetRotateCondition().Add(_ => entity.DoesHealthExist());
            entity.GetRotateAction().Add(entity.RotateStep);
            entity.AddRotationSpeed(_rotateSpeed);
        }
    }
}