using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Gameplay.GameEntity.Content.Zombie
{
    public sealed class ZombieInstaller : GameEntityInstaller
    {
        [BoxGroup("MOVEMENT"), SerializeField] private TransformInstaller _transformInstaller;
        [BoxGroup("MOVEMENT"), SerializeField] private MoveInstaller _moveInstaller;
        [BoxGroup("MOVEMENT"), SerializeField] private Const<float> _moveSpeed = 3;
        [BoxGroup("MOVEMENT"), SerializeField] private Const<float> _rotateSpeed = 360;
        [BoxGroup("MOVEMENT"), SerializeField] private RotateInstaller _rotateInstaller;

        [BoxGroup("HEALTH"), SerializeField] private HealthInstaller _healthInstaller;
        
        [BoxGroup("ATTACK"), SerializeField] private AttackInstaller _attackInstaller;
        [BoxGroup("ATTACK"), SerializeField] private WeaponEntity _weapon;
        
        [BoxGroup("MISC"), SerializeField] private TeamType _team = TeamType.Enemy;
        
        public override void Install(IGameEntity entity)
        {
            entity.AddValue(GameEntityAPI.Team, new Variable<TeamType>(_team));
            
            InstallMovement(entity);
            InstallHealth(entity);
            InstallAttack(entity);
            InstallAI(entity);
        }

        private void InstallMovement(IGameEntity entity)
        {
            _moveInstaller.Install(entity);
            entity.GetValue(GameEntityAPI.MoveCommand)
                .AddCondition(_ => entity.IsAlive())
                .AddAction(_ => entity.MoveWithRootMotion(_moveSpeed));
            
            _transformInstaller.Install(entity);
            
            _rotateInstaller.Install(entity);
            entity.GetValue(GameEntityAPI.RotateCommand)
                .AddCondition(_ => entity.IsAlive())
                .AddAction(entity.RotateStep);
            entity.AddBehaviour(new GameEntityRotationBehaviour());
            

            entity.AddValue(GameEntityAPI.RotationSpeed, _rotateSpeed);
        }

        private void InstallHealth(IGameEntity entity)
        {
            _healthInstaller.Install(entity);
            entity.AddValue(GameEntityAPI.TakeDamageCommand, new Command<int>());
            entity.GetValue(GameEntityAPI.TakeDamageCommand)
                .AddCondition(_ => entity.IsAlive())
                .AddAction(damage => entity.ReduceHealth(damage));
            
            entity.GetValue(GameEntityAPI.DeathEvent).Subscribe(() => entity.DelValue(GameEntityAPI.Team));
        }

        private void InstallAttack(IGameEntity entity)
        {
            _attackInstaller.Install(entity);
            entity.GetValue(GameEntityAPI.AttackCommand)
                .AddCondition(entity.IsAlive)
                .AddCondition(entity.HavePlayerTarget)
                .AddCondition(entity.CanAttackWithWeapon);

            entity.AddValue(GameEntityAPI.AimDirection, new ReactiveVariable<Vector3>());
            
            entity.AddBehaviour(new ZombieAttackBehaviour());
            
            entity.AddValue(GameEntityAPI.Weapon, new Variable<IWeaponEntity>(_weapon));
            _weapon.Install();
        }
        
        private void InstallAI(IGameEntity entity)
        {
            entity.AddValue(GameEntityAPI.Target, new Variable<IGameEntity>());
            entity.AddBehaviour(new AttackTargetBehaviour());
            entity.AddBehaviour(new MoveToTargetBehaviour());
        }
    }
}