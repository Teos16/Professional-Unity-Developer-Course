using Atomic.Entities;
using UnityEngine;

namespace Game.App
{
    public sealed class AppContextInstaller : SceneEntityInstaller<IAppContext>
    {
        [SerializeField]
        private LevelsInstaller _levelsInstaller;

        [SerializeField]
        private GameLoadInstaller _loadGameInstaller;

        [SerializeField]
        private MenuLoadInstaller _menuLoadInstaller;

        public override void Install(IAppContext context)
        {
            _levelsInstaller.Install(context);
            _loadGameInstaller.Install(context);
            _menuLoadInstaller.Install(context);
            
            context.AddBehaviour<QuitController>();
        }
    }
}