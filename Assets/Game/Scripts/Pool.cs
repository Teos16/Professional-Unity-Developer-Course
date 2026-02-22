using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class Pool : MonoBehaviour
    {
        [SerializeField] private Factory _factory;
        [SerializeField] private int _initialCapacity = 10;
        [SerializeField] private bool returnOnDeactivation;

        private readonly List<GameObject> _pool = new();
        
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
            {
                if (!_pool[i].activeSelf) 
                    _pool[i].SetActive(false);
            }
        }

        private void CreateNewInstance()
        {
            GameObject instance = _factory.Create(); 
            instance.SetActive(false);
            _pool.Add(instance);
        }

        public GameObject Rent()
        {
            for (int i = _pool.Count - 1; i >= 0; i--)
            {
                if (!_pool[i].activeSelf)
                {
                    _pool[i].SetActive(true);
                    return _pool[i];
                }
            }

            return _factory.Create();
        }

        public void Return(GameObject instance)
        {
            if (instance == null)
                return;

            instance.SetActive(false);

            if (!_pool.Contains(instance))
                _pool.Add(instance);
        }
    }
}