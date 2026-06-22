using Atomic.Elements;
using Atomic.Entities;

namespace Game.Gameplay
{
    public sealed class FirstAttackDelayBehaviour : IGameEntityInit, IGameEntityTick
    {
        private ICooldown _firstAttackDelay;
        private ICommand _attackCommand;
        private IVariable<bool> _isAiming;
        private bool _delayStarted;

        public void Init(IGameEntity entity)
        {
            _firstAttackDelay = entity.GetValue(GameEntityAPI.FirstAttackDelay);
            _attackCommand = entity.GetValue(GameEntityAPI.AttackCommand);
            _isAiming = entity.GetValue(GameEntityAPI.IsAiming);
        }

        public void Tick(IGameEntity entity, float deltaTime) 
        { 
            if (!_isAiming.Value) 
            { 
                HandleAimLoss(); 
                return; 
            } 

            if (!_delayStarted) 
                StartDelay(); 

            UpdateDelay(deltaTime); 
        } 

        private void HandleAimLoss() 
        { 
            if (!_delayStarted) return; 

            _firstAttackDelay.ResetTime(); 
            _attackCommand.RemoveCondition(Constants.False); 
            _delayStarted = false; 
        } 

        private void StartDelay() 
        { 
            _delayStarted = true; 
            _attackCommand.AddCondition(Constants.False); 
            
            _firstAttackDelay.ResetTime(); 
        } 

        private void UpdateDelay(float deltaTime) 
        { 
            if (_firstAttackDelay.IsCompleted()) 
                return; 

            _firstAttackDelay.Tick(deltaTime); 

            if (_firstAttackDelay.IsCompleted()) 
                _attackCommand.RemoveCondition(Constants.False); 
        } 
    }
}