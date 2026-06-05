using Game.App;
using UnityEngine;

namespace Game.UI
{
    public sealed class LevelScreenPresenter : MonoBehaviour,
        IMenuUIInit,
        IMenuUIDispose,
        IMenuUIEnable,
        IMenuUIDisable,
        IScreenPresenter
    {
        [SerializeField]
        private LevelScreenView _screenView;
        
        private IAppContext _appContext;
        private IMenuUI _menuUI;

        public void Init(IMenuUI context)
        {
            _menuUI = context;
            _appContext = AppContext.Instance;
            this.SpawnLevelItems();
        }

        private void SpawnLevelItems()
        {
            int startLevel = _appContext.GetStartLevel().Value;
            int maxLevel = _appContext.GetMaxLevel().Value;
            for (int i = startLevel; i <= maxLevel; i++)
            {
                LevelItemView itemView = _screenView.CreateItem();
                LevelItemPresenter itemPresenter = new LevelItemPresenter(_appContext, i, itemView);
                _menuUI.AddBehaviour(itemPresenter);
            }
        }

        public void Enable(IMenuUI entity)
        {
            _screenView.OnCloseClicked += this.OnCloseClicked;
            _screenView.Show();
        }

        public void Disable(IMenuUI entity)
        {
            _screenView.OnCloseClicked -= this.OnCloseClicked;
            _screenView.Hide();
        }

        private void OnCloseClicked() => _menuUI.ShowScreen<StartScreenPresenter>();

        public void Dispose(IMenuUI entity)
        {
            _menuUI.DelBehaviours<LevelItemPresenter>();
            _screenView.ClearAllItems();
        }
    }
}