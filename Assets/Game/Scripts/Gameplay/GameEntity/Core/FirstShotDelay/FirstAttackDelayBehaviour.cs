using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class FirstAttackDelayBehaviour : IGameEntityInit, IGameEntityTick
    {
        private IVariable<Vector3> _aimDirection;
        private ICooldown _initialAttackLag;
        private ICommand _attackCommand;
        private bool _lagStarted;

        public void Init(IGameEntity entity)
        {
            _initialAttackLag = entity.GetValue(GameEntityAPI.InitialAttackLag);
            _attackCommand = entity.GetValue(GameEntityAPI.AttackCommand);
        }

        public void Tick(IGameEntity entity, float deltaTime)
        {
            if (!entity.IsAiming())
            {
                HandleAimLoss();
                return;
            }

            TryStartLag();

            TryUpdateLag(deltaTime);
        }
        
        private void HandleAimLoss()
        {
            if (!_lagStarted)
                return;

            if (!_initialAttackLag.IsCompleted())
            {
                _attackCommand.RemoveCondition(Constants.False);
                _initialAttackLag.ResetTime();
            }

            _lagStarted = false;
        }
        
        private void TryStartLag()
        {
            if (_lagStarted)
                return;

            _lagStarted = true;
            _initialAttackLag.ResetTime();
            _attackCommand.AddCondition(Constants.False);
        }
        
        private void TryUpdateLag(float deltaTime)
        {
            if (!_lagStarted || _initialAttackLag.IsCompleted()) 
                return;
            
            _initialAttackLag.Tick(deltaTime);

            if (_initialAttackLag.IsCompleted())
                _attackCommand.RemoveCondition(Constants.False);
        }
    }
}