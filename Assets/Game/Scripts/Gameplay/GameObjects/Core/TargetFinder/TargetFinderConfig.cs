using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Components/TargetFinder")]
    public sealed class TargetFinderConfig : ScriptableObject
    {
        [SerializeField] private float _radius = 8;

        public float Radius => _radius;
    }
}
