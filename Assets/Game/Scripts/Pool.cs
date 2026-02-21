using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class Pool : MonoBehaviour
    {
        [SerializeField] private Factory _factory;
        [SerializeField] private int _initialCapacity = 10;

        private readonly Stack<GameObject> _pool = new();
        
        private void Start()
        {
            for (int i = 0; i < _initialCapacity; i++) 
                CreateNewInstance();
        }

        private void CreateNewInstance()
        {
            GameObject instance = _factory.Create(); 
            instance.gameObject.SetActive(false);
            _pool.Push(instance);
        }

        public GameObject Rent()
        {
            if (_pool.TryPop(out GameObject instance))
            {
                instance.gameObject.SetActive(true);
                return instance;
            }
            
            return _factory.Create();
        }

        public void Return(GameObject instance)
        {
            if (instance == null)
                return;
            
            instance.gameObject.SetActive(false);
            _pool.Push(instance);
        }
    }
}