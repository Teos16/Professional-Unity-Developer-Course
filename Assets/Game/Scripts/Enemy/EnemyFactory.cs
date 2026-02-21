using Game.Enemy;
using Game.ShipRelated;
using UnityEngine;

namespace Game
{
    public sealed class EnemyFactory : Factory
    {
        [SerializeField] private Ship _target;

        protected override void Setup(GameObject instance) => 
            instance.GetComponent<EnemyBehaviour>().Construct(_target);
    }
}