using Game.BulletRelated;
using Modules.Utils;
using UnityEngine;

namespace Game
{
    public sealed class BulletFactory : Factory
    {
        [SerializeField] private TransformBounds _bounds;

        protected override void Setup(GameObject instance) =>
            instance.GetComponent<Bullet>().Construct(_bounds);
    }
}