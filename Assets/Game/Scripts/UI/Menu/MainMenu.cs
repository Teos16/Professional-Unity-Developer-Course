using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private string _gameplayScene = "Gameplay";

        private void OnEnable() => _playButton.onClick.AddListener(OnPlayClicked);

        private void OnDisable() => _playButton.onClick.RemoveListener(OnPlayClicked);

        private void OnPlayClicked() => SceneManager.LoadScene(_gameplayScene);
    }
}
