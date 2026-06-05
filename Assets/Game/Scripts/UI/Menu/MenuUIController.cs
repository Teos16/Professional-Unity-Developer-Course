using Atomic.Elements;
using Game.App;

namespace Game.UI
{
    public sealed class MenuUIController : IMenuUIInit, IMenuUIEnable, IMenuUIDispose
    {
        private readonly IAppContext _appContext;
        private IMenuUI _menuUI;
        private Subscription _subscription;

        public MenuUIController(IAppContext appContext)
        {
            _appContext = appContext;
        }

        public void Init(IMenuUI menuUI)
        {
            _menuUI = menuUI;
            _subscription = _appContext.GetMenuLoadedEvent().Subscribe(this.OnMenuLoaded);
        }

        public void Enable(IMenuUI entity)
        {
            if (_appContext.InMenu()) 
                _menuUI.ShowScreen<StartScreenPresenter>();
        }

        public void Dispose(IMenuUI entity)
        {
            _subscription.Dispose();
        }

        private void OnMenuLoaded()
        {
            _menuUI.ShowScreen<StartScreenPresenter>();
        }
    }
}