using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Pool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private Factory<T> _factory;
        [SerializeField] private int _initialCapacity = 10;
        [SerializeField] private bool returnOnDeactivation;

        private readonly List<T> _pool = new();
        
        private void Start()
        {
            for (int i = 0; i < _initialCapacity; i++) 
                CreateNewInstance();
        }

        private void LateUpdate()
        {
            if (!returnOnDeactivation) 
                return;

            for (int i = _pool.Count - 1; i >= 0; i--)
                if(!_pool[i].gameObject.activeSelf)
                    Return(_pool[i]);
        }

        public T Rent()
        {
            for (int i = _pool.Count - 1; i >= 0; i--)
                if (!_pool[i].gameObject.activeSelf)
                {
                    OnRent(i);
                    return _pool[i];
                }

            return _factory.Create();
        }

        public void Return(T instance)
        {
            if (instance == null)
                return;

            OnReturn(instance);

            if (!_pool.Contains(instance))
                _pool.Add(instance);
        }

        protected virtual void OnRent(int i) => _pool[i].gameObject.SetActive(true);

        protected virtual void OnReturn(T instance) => instance.gameObject.SetActive(false);

        private void CreateNewInstance()
        {
            T instance = _factory.Create(); 
            instance.gameObject.SetActive(false);
            _pool.Add(instance);
        }
    }
}