using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileWorld : NetworkBehaviour
    {
        private const int PROJECTILE_CAPACITY = 32;

        [Networked, Capacity(PROJECTILE_CAPACITY)]
        private NetworkArray<Projectile> _projectiles { get; }

        public int Length => PROJECTILE_CAPACITY;
        
        [SerializeField] private ProjectileConfig _config;

        public ref readonly Projectile GetProjectileAt(int index)
        {
            return ref _projectiles.GetRef(index);
        }
        
        public bool TrySpawn(Vector3 position, Quaternion rotation)
        {
            if (!this.FindFreeSlot(out int index))
                return false;

            _projectiles.Set(index, new Projectile
            {
                startPosition = position,
                startRotation = rotation,
                startTick = this.Runner.Tick
            });

            return true;
        }

        public override void FixedUpdateNetwork()
        {
            PlayerRef player = this.Object.InputAuthority;
            NetworkRunner runner = this.Runner;

            for (int i = 0; i < PROJECTILE_CAPACITY; i++)
            {
                ref Projectile projectile = ref _projectiles.GetRef(i);
                if (!projectile.IsAlive)
                    continue;

                _config.Simulate(in projectile, player, runner, out bool finished);

                if (finished)
                    projectile = default;
            }
        }

        private bool FindFreeSlot(out int index)
        {
            for (int i = 0; i < PROJECTILE_CAPACITY; i++)
            {
                Projectile projectile = _projectiles[i];
                if (!projectile.IsAlive)
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        private void OnDrawGizmos()
        {
            if (!this.StateBufferIsValid)
                return;

            PlayerRef player = this.Object.InputAuthority;
            NetworkRunner runner = this.Runner;

            for (int i = 0; i < PROJECTILE_CAPACITY; i++)
            {
                ref readonly Projectile projectile = ref _projectiles.GetRef(i);
                if (projectile.IsAlive)
                    _config.DrawGizmos(in projectile, player, runner);
            }
        }
    }
}