using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileView : MonoBehaviour
    {
        [SerializeField] private ProjectileConfig _config;

        public void OnSpawn(in Projectile projectile, PlayerRef player, NetworkRunner runner)
        {
            this.transform.rotation = projectile.startRotation;
            this.UpdatePosition(in projectile, player, runner);
        }

        public void OnUpdate(in Projectile projectile, PlayerRef player, NetworkRunner runner)
        {
            this.UpdatePosition(in projectile, player, runner);
        }
        
        public void OnDespawn(PlayerRef player, NetworkRunner runner)
        {
            //Destroy(gameObject);
        }

        private void UpdatePosition(in Projectile projectile, PlayerRef player, NetworkRunner runner)
        {
            this.transform.position = _config.GetRenderPosition(in projectile, player, runner);
        }
    }
}