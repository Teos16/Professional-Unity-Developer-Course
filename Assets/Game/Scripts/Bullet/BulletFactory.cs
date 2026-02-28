using Modules.Utils;
using UnityEngine;

namespace Game.Bullets
{
    public sealed class BulletFactory : Factory<Bullet>
    {
        [SerializeField] private TransformBounds _bounds;

        protected override void Setup(Bullet bullet) => bullet.Construct(_bounds);
    }
}