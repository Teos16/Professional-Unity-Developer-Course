using Cysharp.Threading.Tasks;
using Game.App;

namespace Game.UI
{
    public sealed class LevelItemPresenter : IMenuUIInit, IMenuUIDispose
    {
        private readonly IAppContext _context;
        private readonly LevelItemView _view;
        private readonly int _level;
        
        public LevelItemPresenter(IAppContext context, int level, LevelItemView view)
        {
            _context = context;
            _view = view;
            _level = level;
        }

        public void Init(IMenuUI context)
        {
            int currentLevel = _context.GetCurrentLevel().Value;
            if (currentLevel == _level)
                _view.SetAsCurrent();
            else if (currentLevel > _level)
                _view.SetAsCompleted();
            else
                _view.SetAsNotCompleted();

            _view.SetLevel(_level.ToString());
            _view.OnClicked += this.OnClicked;
        }

        public void Dispose(IMenuUI entity)
        {
            _view.OnClicked -= this.OnClicked;
        }

        private void OnClicked() => _context.LoadGame(_level).Forget();
    }
}