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
        private Variable<float> _baseArmor = 0.5f;

        [SerializeField]
        private InteractorInstaller _interactorInstaller;

        [SerializeField]
        private TakeDamageInstaller _takeDamageInstaller;

        [SerializeField]
        private GravityInstaller _gravityInstaller;

        [SerializeField]
        private WeaponEntity _weapon;

        [SerializeField]
        private TriggerEvents _triggerEvents;

        [SerializeField]
        private ReactiveVariable<TeamType> _team;

        public override void Install(IGameEntity entity)
        {
            entity.AddCharacterTag();
            entity.AddTransform(this.transform);
            entity.AddTeam(_team);

            _transformInstaller.Install(entity);
            _healthInstaller.Install(entity);

            entity.AddArmor(_baseArmor);
            entity.AddArmorMultiplier(new FloatSumExpression());
            entity.AddIsStunned(new OrExpression());
            
            _moveInstaller.Install(entity);
            _fireInstaller.Install(entity);
            _interactorInstaller.Install(entity);
            _gravityInstaller.Install(entity);

            entity.AddTrigger(_triggerEvents);
            entity.AddWeapon(new ReactiveVariable<IWeaponEntity>(_weapon));
            entity.AddRespawnCommand(new Command()
                .AddAction(entity.SetMaxHealth)
            );
            entity.AddCurrentTransport(new Variable<IGameEntity>());
            entity.AddIsSheep(new ReactiveVariable<bool>(false));
            
            entity.AddDamageMultiplier(new FloatMulExpression());

            InstallRotation(entity);
            InstallTakeDamage(entity);
            InstallEffects(entity);
        }

        private void InstallTakeDamage(IGameEntity entity)
        {
            _takeDamageInstaller.Install(entity);
            entity.GetTakeDamageCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddAction(damage =>
                {
                    float baseArmorPercent = entity.GetArmor().Value;
                    float armorMultiplier = entity.GetArmorMultiplier().Value;
                    entity.ReduceHealthWithArmor(damage, baseArmorPercent + armorMultiplier);
                });
        }

        private void InstallRotation(IGameEntity entity)
        {
            _rotateInstaller.Install(entity);
            entity.GetRotateCommand()
                .AddCondition(_ => entity.IsHealthExists())
                .AddCondition(_ => !entity.GetIsStunned().Value)
                .AddAction(entity.RotateStep);

            entity.AddRotationSpeed(_rotateSpeed);
        }

        private void InstallEffects(IGameEntity entity)
        {
            entity.AddEffects(new ReactiveList<Effect>());
            entity.AddBehaviour<UpdateEffectsBehaviour>();
        }
    }
}