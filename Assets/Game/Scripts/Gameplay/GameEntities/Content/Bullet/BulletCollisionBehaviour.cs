using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BulletCollisionBehaviour : IGameEntityInit, IGameEntityDispose
    {
        private readonly IGameContext _gameContext;

        private IValue<EffectConfig> _effectConfig;
        private TriggerEvents _trigger;
        private IValue<int> _damage;
        private IValue<float> _damageMultiplier;
        private IValue<TeamType> _team;
        private IAction _destroyAction;

        public BulletCollisionBehaviour(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void Init(IGameEntity entity)
        {
            _damage = entity.GetDamage();
            _damageMultiplier = entity.GetDamageMultiplier();
            
            _effectConfig = entity.GetEffect();
            
            _team = entity.GetTeam();
            _destroyAction = entity.GetDestroyAction();
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += OnTriggerEnter;
        }

        public void Dispose(IGameEntity entity)
        {
            _trigger.OnEntered -= OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IGameEntity target))
            {
                if (_gameContext.TakeDamage(target, CalculateDamage(), _team.Value))
                {
                    if (_effectConfig.Value != null)
                    {
                        target.ApplyEffect(_effectConfig.Value);
                    }
                    _destroyAction.Invoke();
                }
            }
        }

        private int CalculateDamage()
        {
            int damageValue = _damage.Value;
            float multiplier = _damageMultiplier.Value;
            int damage = Mathf.RoundToInt(damageValue * multiplier);
            return damage;
        }
    }
}