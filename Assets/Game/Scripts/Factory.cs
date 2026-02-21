using UnityEngine;

namespace Game
{
    public abstract class Factory : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _container;
        
        protected abstract void Setup(GameObject instance);
        
        public GameObject Create()
        {
            GameObject instance = Instantiate(_prefab, _container);
            Setup(instance);
            return instance;
        }
    }
}