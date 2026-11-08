using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileWorld : NetworkBehaviour
    {
        private const int PROJECTILE_CAPACITY = 32;

        [SerializeField] private ProjectileConfig _config;

        [Networked, Capacity(PROJECTILE_CAPACITY)]
        private NetworkArray<Projectile> _projectiles { get; }

        public int Length => PROJECTILE_CAPACITY;

        public ref readonly Projectile GetProjectileAt(int index) => ref _projectiles.GetRef(index);

        public bool TrySpawn(Vector3 position, Quaternion rotation)
        {
            if (!FindFreeSlot(out int index))
                return false;

            _projectiles.Set(index, new Projectile
            {
                startPosition = position,
                startRotation = rotation,
                startTick = Runner.Tick
            });

            return true;
        }

        public override void FixedUpdateNetwork()
        {
            PlayerRef player = Object.InputAuthority;

            for (int i = 0; i < PROJECTILE_CAPACITY; i++)
            {
                ref Projectile projectile = ref _projectiles.GetRef(i);
                if (!projectile.IsAlive)
                    continue;

                _config.Simulate(in projectile, player, Runner, out bool finished);

                if (finished)
                    projectile = default;
            }
        }

        private bool FindFreeSlot(out int index)
        {
            for (int i = 0; i < PROJECTILE_CAPACITY; i++)
            {
                if (!_projectiles[i].IsAlive)
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
            if (!StateBufferIsValid)
                return;

            PlayerRef player = Object.InputAuthority;

            for (int i = 0; i < PROJECTILE_CAPACITY; i++)
            {
                ref readonly Projectile projectile = ref _projectiles.GetRef(i);
                if (projectile.IsAlive)
                    _config.DrawGizmos(in projectile, player, Runner);
            }
        }
    }
}
