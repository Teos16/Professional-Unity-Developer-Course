using Fusion;

namespace Game
{
    public sealed class Mine : NetworkBehaviour
    {
        private ExplosionComponent _explosion;

        public override void Spawned() => _explosion = GetBehaviour<ExplosionComponent>();

        public override void FixedUpdateNetwork()
        {
            if (HasStateAuthority && _explosion.TryExplode())
                Runner.Despawn(Object);
        }
    }
}
