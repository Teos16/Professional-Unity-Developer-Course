using Fusion;

namespace Game
{
    public sealed class EnemyDeathController : NetworkBehaviour
    {
        private EnemyRegistry _enemyRegistry;
        private Wallet _wallet;

        public override void Spawned()
        {
            _enemyRegistry = GetBehaviour<EnemyRegistry>();
            _wallet = GetBehaviour<Wallet>();
        }

        public override void FixedUpdateNetwork()
        {
            if (!HasStateAuthority)
                return;

            foreach (NetworkObject enemy in _enemyRegistry.Enemies)
            {
                if (!enemy.TryGetBehaviour(out HealthComponent health) || health.IsAlive)
                    continue;

                if (enemy.TryGetBehaviour(out RewardComponent reward))
                    _wallet.Add(reward.Roll());

                Runner.Despawn(enemy);
            }
        }
    }
}