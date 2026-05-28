using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    public sealed class CharacterDeathBehaviour : IEntityInit, IEntityDispose
    {
        
        private IReactiveVariable<int> _health;
        private GameObject _gameObject;
        
        public void Init(IEntity entity)
        {
            _gameObject = entity.GetGameObject();
            _health = entity.GetHealth();
            _health.OnEvent += OnHealthChanged;
        }

        public void Dispose(IEntity entity)
        {
            _health.OnEvent -= OnHealthChanged;
        }

        private void OnHealthChanged(int health)
        {
            _gameObject.SetActive(health > 0);
        }
    }
}