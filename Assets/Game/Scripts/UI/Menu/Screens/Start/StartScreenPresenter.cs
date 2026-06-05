using Game.App;
using UnityEngine;

namespace Game.UI
{
    public sealed class StartScreenPresenter : MonoBehaviour,
        IMenuUIInit,
        IMenuUIEnable,
        IMenuUIDisable,
        IScreenPresenter
    {
        [SerializeField]
        private StartScreenView _screenView;
        
        private IAppContext _appContext;
        private IMenuUI _menuUI;

        public void Init(IMenuUI context)
        {
            _menuUI = context;
            _appContext = AppContext.Instance;
        }

        public void Enable(IMenuUI context)
        {
            _screenView.OnSelectLevelClicked += OnSelectLevelClicked;
            _screenView.OnStartClicked += OnStartClicked;
            _screenView.OnExitClicked += _appContext.Quit;
            _screenView.Show();
        }

        public void Disable(IMenuUI context)
        {
            _screenView.OnStartClicked -= OnStartClicked;
            _screenView.OnSelectLevelClicked -= OnSelectLevelClicked;
            _screenView.OnExitClicked -= _appContext.Quit;
            _screenView.Hide();
        }

        private void OnStartClicked() => _appContext.LoadGame();

        private void OnSelectLevelClicked() => _menuUI.ShowScreen<LevelScreenPresenter>();
    }
}