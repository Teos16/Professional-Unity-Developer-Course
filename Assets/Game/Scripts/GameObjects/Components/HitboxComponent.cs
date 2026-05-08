using UnityEngine;

namespace SampleGame
{
    public sealed class HitboxComponent : MonoBehaviour
    {
        [SerializeField]
        private GameObject _root;

        public GameObject Root => _root;

        public bool TryGetRootComponent<T>(out T component) => 
            _root.TryGetComponent(out component);
    }
}