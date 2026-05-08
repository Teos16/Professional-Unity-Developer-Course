using UnityEngine;

namespace SampleGame
{
    public class TargetComponent : MonoBehaviour
    {
        public GameObject Target
        {
            get { return _target; }
            set => _target = value;
        }

        [SerializeField] private GameObject _target;
    }
}