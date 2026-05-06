using System;
using Cysharp.Threading.Tasks;
using SampleGame.Gameplay;

namespace Game.UI
{
    public sealed class ControlsPresenter : IControlsPresenter
    {
        private readonly EntitySaveManager _saveManager;

        public ControlsPresenter(EntitySaveManager saveManager) => _saveManager = saveManager;

        public void Save(Action<bool, int> callback) => SaveAsync(callback).Forget();

        public void Load(string version, Action<bool, int> callback) => LoadAsync(version, callback).Forget();
        
        private async UniTaskVoid SaveAsync(Action<bool, int> callback)
        {
            (bool success, int savedVersion) = await _saveManager.Save();
            callback?.Invoke(success, savedVersion);
        }

        private async UniTaskVoid LoadAsync(string version, Action<bool, int> callback)
        {
            bool success = await _saveManager.Load(version);
            int parsedVersion = int.TryParse(version, out int v) ? v : 0;
            callback?.Invoke(success, parsedVersion);
        }
    }
}