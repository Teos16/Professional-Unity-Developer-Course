using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class CameraFollower : NetworkBehaviour
    {
        [SerializeField]
        private Character _character;
        
        private Transform _pivot;

        public override void Spawned() => _pivot = Camera.main?.transform.parent;

        public override void Render()
        {
            if(HasInputAuthority) 
                _pivot.position = _character.transform.position;
        }
    }
}