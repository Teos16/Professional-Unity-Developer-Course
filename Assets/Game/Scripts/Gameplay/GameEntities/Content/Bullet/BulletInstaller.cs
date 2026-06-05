using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BulletInstaller : GameEntityInstaller
    {
        [SerializeField]
        private TransformInstaller _transformInstaller;

        [SerializeField]
        private LifetimeInstaller _lifetimeInstaller;

        [SerializeField]
        private TriggerEvents _triggerEvents;

        [SerializeField]
        private Const<int> _damage;

        [SerializeField]
        private Const<float> _moveSpeed = 10;

        [SerializeField]
        private ReactiveVariable<TeamType> _team;

        public override void Install(IGameEntity entity)
        {
            GameContext gameContext = GameContext.Instance;

            _transformInstaller.Install(entity);
            _lifetimeInstaller.Install(entity);
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddTeam(_team);
            entity.AddTrigger(_triggerEvents);
            entity.AddDamage(_damage);
            entity.WhenFixedTick(entity.MoveStepForward);
            entity.AddBehaviour(new BulletCollisionBehaviour(gameContext));
            entity.AddDestroyAction(new InlineAction(() => gameContext.DespawnBullet(entity)));
            entity.AddRespawnAction(new InlineAction(() => entity.GetLifetime().ResetTime()));
        }
    }
}