using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public sealed class SessionShutdownController : MonoBehaviour
    {
        [SerializeField] private string _menuScene = "Menu";

        private NetworkEvents _networkEvents;

        private void Awake() => _networkEvents = GetComponent<NetworkEvents>();

        private void OnEnable() => _networkEvents.OnShutdown.AddListener(OnShutdown);

        private void OnDisable() => _networkEvents.OnShutdown.RemoveListener(OnShutdown);

        private void OnShutdown(NetworkRunner runner, ShutdownReason reason)
        {
            Debug.Log($"Session shutdown: {reason}");
            SceneManager.LoadScene(_menuScene);
        }
    }
}
