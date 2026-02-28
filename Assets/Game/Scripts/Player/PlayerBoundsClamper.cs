using Game.Ships;
using Modules.Utils;
using UnityEngine;

namespace Game.Player
{
    public sealed class PlayerBoundsClamper : MonoBehaviour
    {
        [SerializeField] private TransformBounds _bounds;
        [SerializeField] private Ship _ship;
        
        private void Update() => _ship.transform.position = _bounds.ClampInBounds(_ship.transform.position);
    }
}