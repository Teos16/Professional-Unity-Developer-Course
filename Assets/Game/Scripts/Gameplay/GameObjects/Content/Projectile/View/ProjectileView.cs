using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileView : MonoBehaviour
    {
        [SerializeField] private ProjectileConfig _config;

        public void OnSpawn(in Projectile projectile, PlayerRef player, NetworkRunner runner)
        {
            transform.rotation = projectile.startRotation;
            UpdatePosition(in projectile, player, runner);
        }

        public void OnUpdate(in Projectile projectile, PlayerRef player, NetworkRunner runner) =>
            UpdatePosition(in projectile, player, runner);

        public void OnDespawn(PlayerRef player, NetworkRunner runner)
        {
        }

        private void UpdatePosition(in Projectile projectile, PlayerRef player, NetworkRunner runner) =>
            transform.position = _config.GetRenderPosition(in projectile, player, runner);
    }
}
