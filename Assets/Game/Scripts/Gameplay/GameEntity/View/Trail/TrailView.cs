using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TrailView : MonoBehaviour
    {
        [SerializeField] TrailRenderer _trailRenderer;

        private void OnDisable() => _trailRenderer.Clear();
    }
}