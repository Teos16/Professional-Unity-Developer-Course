using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileWorldView : NetworkBehaviour
    {
        [SerializeField] private ProjectileView _viewPrefab;

        private ProjectileWorld _world;
        private ProjectileView[] _projectileViews;
        private Transform _container;

        public override void Spawned()
        {
            _world = GetBehaviour<ProjectileWorld>();
            _projectileViews = new ProjectileView[_world.Length];

            ProjectileContainer container = FindFirstObjectByType<ProjectileContainer>();
            _container = container != null ? container.transform : null;
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            foreach (ProjectileView view in _projectileViews)
            {
                if (view != null)
                    Destroy(view.gameObject);
            }
        }

        public override void Render()
        {
            PlayerRef player = Object.InputAuthority;
            NetworkRunner runner = Runner;

            for (int i = 0; i < _world.Length; i++)
            {
                ref readonly Projectile projectile = ref _world.GetProjectileAt(i);
                ref ProjectileView view = ref _projectileViews[i];

                bool projectileExists = projectile.IsAlive;
                bool viewExists = view != null;

                if (projectileExists && !viewExists)
                {
                    // Spawn
                    view = Instantiate(_viewPrefab, _container);
                    view.OnSpawn(in projectile, player, runner);
                }
                else if (viewExists && !projectileExists)
                {
                    // Despawn
                    view.OnDespawn(player, runner);
                    Destroy(view.gameObject);
                    view = null;
                }
                else if (projectileExists)
                {
                    // Update
                    view.OnUpdate(in projectile, player, runner);
                }
            }
        }
    }
}
