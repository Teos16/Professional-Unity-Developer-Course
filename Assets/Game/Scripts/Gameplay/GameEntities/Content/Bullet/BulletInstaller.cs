using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BulletInstaller : GameEntityInstaller
    {
        [SerializeField] private TransformInstaller _transformInstaller;
        [SerializeField] private LifetimeInstaller _lifetimeInstaller;
        [SerializeField] private TriggerEvents _triggerEvents;
        [SerializeField] private Const<int> _damage;
        [SerializeField] private Const<float> _moveSpeed = 10;
        [SerializeField] private ReactiveVariable<TeamType> _team;
        [SerializeField] private Variable<EffectConfig> _effectConfig;

        public override void Install(IGameEntity entity)
        {
            GameContext gameContext = GameContext.Instance;

            _transformInstaller.Install(entity);
            _lifetimeInstaller.Install(entity);
            entity.AddTeam(_team);
            entity.AddTrigger(_triggerEvents);
            entity.AddDamage(_damage);
            entity.AddDamageMultiplier(new FloatMulExpression());
            
            entity.AddEffect(_effectConfig);
            
            entity.WhenFixedTick(dt => entity.MoveStepForward(_moveSpeed, dt));
            entity.AddBehaviour(new BulletCollisionBehaviour(gameContext));
            entity.AddDestroyAction(new InlineAction(() => gameContext.DespawnBullet(entity)));

            entity.AddRespawnCommand(new Command()
                .AddAction(entity.GetLifetime().ResetTime)
            );
        }
    }
}