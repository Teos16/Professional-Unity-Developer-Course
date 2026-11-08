using Fusion;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Projectile", order = 2)]
    public sealed class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private float _speed = 5;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _lifetime;
        [SerializeField] private int _damage = 1;

        public void Simulate(
            in Projectile projectile,
            PlayerRef player,
            NetworkRunner runner,
            out bool finished)
        {
            finished = false;

            float deltaTime = runner.DeltaTime;
            float currentTime = (runner.Tick - projectile.startTick) * deltaTime;
            if (currentTime > _lifetime)
            {
                finished = true;
                return;
            }

            Vector3 direction = projectile.StartDirection;
            float previousTime = Mathf.Max(0, currentTime - deltaTime);
            Vector3 previousPosition =
                projectile.startPosition + direction * previousTime * _speed;

            bool wasHit = runner
                .GetPhysicsScene()
                .Raycast(
                    previousPosition, direction, out RaycastHit hit,
                    _speed * deltaTime, _layerMask, QueryTriggerInteraction.Ignore);

            if (wasHit)
            {
                DealDamage(hit.collider);
                finished = true;
            }
        }

        public void DrawGizmos(in Projectile projectile, PlayerRef player, NetworkRunner runner)
        {
            Color prevColor = Gizmos.color;

            Gizmos.color = runner.LocalPlayer == player ? Color.blue : Color.red;

            float currentTime =
                (runner.Tick - projectile.startTick) * runner.DeltaTime;
            Vector3 position = projectile.startPosition +
                               projectile.StartDirection * currentTime * _speed;

            const float radius = 0.125f;
            Gizmos.DrawSphere(position, radius);
            Gizmos.color = prevColor;
        }

        public Vector3 GetRenderPosition(in Projectile projectile, PlayerRef player, NetworkRunner runner)
        {
            float deltaTime = runner.DeltaTime;
            float spawnTime = projectile.startTick * deltaTime;
            float renderTime = runner.LocalPlayer == player
                ? runner.LocalRenderTime + deltaTime
                : runner.RemoteRenderTime + deltaTime;
            float t = renderTime - spawnTime;
            return projectile.startPosition + projectile.StartDirection * t * _speed;
        }

        private void DealDamage(Collider collider)
        {
            NetworkObject target = collider.GetComponentInParent<NetworkObject>();
            if (target != null && target.IsValid &&
                target.TryGetBehaviour(out HealthComponent health) && health.IsAlive)
                health.TakeDamage(_damage);
        }
    }
}
