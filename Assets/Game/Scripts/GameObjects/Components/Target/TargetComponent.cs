using UnityEngine;

namespace Game
{
    public sealed class TargetComponent : MonoBehaviour
    {
        [field:SerializeField] public GameObject Target { get; set; }
    }
}