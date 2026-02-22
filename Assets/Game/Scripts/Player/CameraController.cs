using Game.Ships;
using Modules.Utils;
using UnityEngine;

namespace Game.Player
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraShaker _cameraShaker;
        [SerializeField] private Ship _player;

        private void Start() => _player.OnHealthChanged += OnHealthChanged;

        private void OnDestroy() => _player.OnHealthChanged -= OnHealthChanged;

        private void OnHealthChanged(int health, int maxHealth) => _cameraShaker.Shake();
    }
}