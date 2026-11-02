using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class PlayerLeftController : MonoBehaviour
    {
        [SerializeField]
        private NetworkEvents _events;

        private void OnEnable()
        {
            _events.PlayerLeft.AddListener(this.OnPlayerLeft);
        }

        private void OnDisable()
        {
            _events.PlayerLeft.RemoveListener(this.OnPlayerLeft);
        }

        private void OnPlayerLeft(NetworkRunner runner, PlayerRef playerRef)
        {
            if (runner.IsServer &&
                runner.TryGetPlayerObject(
                    playerRef, out NetworkObject character))
                runner.Despawn(character);
        }
    }
}