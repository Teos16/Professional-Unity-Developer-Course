using Atomic.Elements;

namespace Game.App
{
    public sealed class LevelSaveLoadController : IAppContextInit, IAppContextEnable, IAppContextDispose
    {
        private IReactiveVariable<int> _currentLevel;
        private ILevelRepository _levelRepository;

        public void Init(IAppContext context)
        {
            _currentLevel = context.GetCurrentLevel();
            _levelRepository = context.GetLevelRepository();
            _currentLevel.OnEvent += _levelRepository.Save;
        }

        public void Enable(IAppContext entity)
        {
            if (_levelRepository.Load(out int level))
                _currentLevel.Value = level;            
        }

        public void Dispose(IAppContext context)
        {
            _currentLevel.OnEvent -= _levelRepository.Save;
        }
    }
}