using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Mine : NetworkBehaviour
    {
        [SerializeField] private float _radius = 1;
        [SerializeField] private int _damage = 5;

        private ExplosionComponent _explosion;

        public override void Spawned()
        {
            _explosion = this.GetBehaviour<ExplosionComponent>();
            _explosion.Initialize(_radius, _damage);
        }

        public override void FixedUpdateNetwork()
        {
            if (this.HasStateAuthority && _explosion.TryExplode())
                this.Runner.Despawn(this.Object);
        }
    }
}