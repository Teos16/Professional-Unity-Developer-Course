using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
    public abstract class Effect
    {
        [ShowInInspector]
        public bool IsActive => _currentTime > 0;
    
        [ShowInInspector]
        public bool IsCompleted => _currentTime <= 0;
    
        [ShowInInspector]
        private float _currentTime;
    
        protected Effect(EffectConfig config)
        {
            _currentTime = config.Duration;
        }
    
        [Button]
        public bool Cancel()
        {
            if (this.IsCompleted)
                return false;
    
            _currentTime = 0;
            this.OnComplete();
            return true;
        }
    
        public void Update(float deltaTime)
        {
            if (_currentTime <= 0)
                return;
    
            this.OnUpdate(deltaTime);
            
            _currentTime = Mathf.Max(0, _currentTime - deltaTime);
            if (_currentTime <= 0)
                this.OnComplete();
        }
    
        protected virtual void OnUpdate(float deltaTime)
        {
        }
    
        protected abstract void OnComplete();
    }
}