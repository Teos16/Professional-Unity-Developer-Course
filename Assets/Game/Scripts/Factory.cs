using UnityEngine;

namespace Game
{
    public abstract class Factory<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _container;
        
        protected abstract void Setup(T instance);
        
        public T Create()
        {
            T instance = Instantiate(_prefab, _container);
            Setup(instance);
            return instance;
        }
    }
}