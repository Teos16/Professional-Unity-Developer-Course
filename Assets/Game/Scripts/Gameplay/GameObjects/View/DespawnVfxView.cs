using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class DespawnVfxView : NetworkBehaviour
    {
        [SerializeField] private ParticleSpawner _vfx;

        public override void Despawned(NetworkRunner runner, bool hasState) => _vfx.Play();
    }
}
