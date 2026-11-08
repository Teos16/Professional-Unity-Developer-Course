using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public sealed class FusionBootstrap : MonoBehaviour
    {
        private async void Start()
        {
            NetworkRunner runner = gameObject.AddComponent<NetworkRunner>();

            NetworkSceneInfo sceneInfo = new NetworkSceneInfo();
            sceneInfo.AddSceneRef(SceneRef.FromIndex(
                SceneManager.GetActiveScene().buildIndex));

            INetworkSceneManager sceneManager = gameObject
                .AddComponent<NetworkSceneManagerDefault>();

            StartGameResult result = await runner.StartGame(
                new StartGameArgs
                {
                    GameMode = GameMode.AutoHostOrClient,
                    SessionName = "SampleSession",
                    PlayerCount = 2,
                    Scene = sceneInfo,
                    SceneManager = sceneManager
                });

            if (result.Ok)
            {
                Debug.Log("Game started successfully");
            }
            else
            {
                Debug.LogError($"StartGame failed: {result.ShutdownReason}");
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
