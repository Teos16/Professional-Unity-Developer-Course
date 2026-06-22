using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    
    public sealed class CharacterInstaller : GameEntityInstaller
    {
        [BoxGroup("MOVEMENT"), SerializeField] private MoveInstaller _moveInstaller;
        [BoxGroup("MOVEMENT"), SerializeField] private Const<float> _moveSpeed = 1;
        [BoxGroup("MOVEMENT"), SerializeField] private TransformInstaller _transformInstaller;
        [BoxGroup("MOVEMENT"), SerializeField] private Const<float> _rotateSpeed = 360;
        [BoxGroup("MOVEMENT"), SerializeField] private RotateInstaller _rotateInstaller;

        [BoxGroup("HEALTH"), SerializeField] private HealthInstaller _healthInstaller;

        [BoxGroup("ATTACK"), SerializeField] private AttackInstaller _attackInstaller;
        [BoxGroup("ATTACK"), SerializeField] private WeaponEntity _weapon;
        [BoxGroup("ATTACK"), SerializeField] private Cooldown _firstAttackDelay = 0.5f;
        
        [BoxGroup("INTERACTION"), SerializeField] private InteractorInstaller _interactorInstaller;
        [BoxGroup("INTERACTION"), SerializeField] private CollisionEvents _collisionEvents;
        
        [BoxGroup("MISC"), SerializeField] private TeamType _team = TeamType.Player;
        
        public override void Install(IGameEntity entity)
        {
            entity.AddTag(GameEntityAPI.PlayerTag);
            entity.AddValue(GameEntityAPI.Team, new Variable<TeamType>(_team));
            
            InstallMovement(entity);
            InstallHealth(entity);
            InstallAttack(entity);
            InstallInteraction(entity);
        }

        private void InstallMovement(IGameEntity entity)
        {
            _moveInstaller.Install(entity);
            entity.GetValue(GameEntityAPI.MoveCommand)
                .AddCondition(_ => entity.IsAlive())
                .AddAction(_ => entity.MoveWithRootMotion(_moveSpeed))
                .AddAction(args => entity.RotateStep(args.direction, args.deltaTime));
            
            _transformInstaller.Install(entity);
            
            _rotateInstaller.Install(entity);
            entity.GetValue(GameEntityAPI.RotateCommand)
                .AddCondition(_ => entity.IsAlive())
                .AddAction(entity.RotateStep);

            entity.AddValue(GameEntityAPI.RotationSpeed, _rotateSpeed);
        }

        private void InstallHealth(IGameEntity entity)
        {
            _healthInstaller.Install(entity);
            entity.AddValue(GameEntityAPI.TakeDamageCommand, new Command<int>());
            entity.GetValue(GameEntityAPI.TakeDamageCommand)
                .AddCondition(_ => entity.IsAlive())
                .AddAction(damage => entity.ReduceHealth(damage));
        }

        private void InstallAttack(IGameEntity entity)
        {
            _attackInstaller.Install(entity);
            entity.GetValue(GameEntityAPI.AttackCommand)
                .AddCondition(entity.IsAlive)
                .AddCondition(entity.CanAttackWithWeapon)
                .AddAction(entity.AttackWithWeapon);

            entity.AddValue(GameEntityAPI.IsAiming, new Variable<bool>());
            entity.AddValue(GameEntityAPI.FirstAttackDelay, _firstAttackDelay);
            entity.AddBehaviour(new FirstAttackDelayBehaviour());
            
            entity.AddValue(GameEntityAPI.Weapon, new Variable<IWeaponEntity>(_weapon));
            _weapon.Install();
        }

        private void InstallInteraction(IGameEntity entity)
        {
            _interactorInstaller.Install(entity);
            entity.AddValue(GameEntityAPI.TargetDetectionType,
                new InlinePredicate<IGameEntity>(e => e.IsInteractable()));
            entity.AddValue(GameEntityAPI.CollisionEvents, _collisionEvents);
            entity.AddBehaviour(new InteractBehaviour());
        }
    }
}