using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class CameraFollower : NetworkBehaviour
    {
        [SerializeField]
        private Character _character;
        
        private Transform _pivot;

        public override void Spawned()
        {
            Camera camera = Camera.main;
            if (camera != null)
                _pivot = camera.transform.parent;
        }

        public override void Render()
        {
            if (HasInputAuthority && _pivot != null)
                _pivot.position = this.transform.position;
        }
    }
}