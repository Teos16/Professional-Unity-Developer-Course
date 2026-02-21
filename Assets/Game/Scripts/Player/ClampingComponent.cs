using Modules.Utils;
using UnityEngine;

namespace Game.Player
{
    public sealed class ClampingComponent : MonoBehaviour
    {
        [SerializeField] private TransformBounds _bounds;
        
        private void Update() => transform.position = _bounds.ClampInBounds(transform.position);
    }
}