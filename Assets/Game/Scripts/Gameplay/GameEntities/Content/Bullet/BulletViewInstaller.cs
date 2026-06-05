using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BulletViewInstaller : GameEntityInstaller
    {
        [SerializeField]
        private Renderer _renderer;

        [SerializeField]
        private TeamCatalog _teamCatalog;

        private readonly DisposableComposite _disposables = new();

        public override void Install(IGameEntity entity)
        {
            entity
                .GetTeam()
                .Observe(team => _renderer.material = _teamCatalog.GetTeam(team).Material)
                .AddTo(_disposables);
        }

        public override void Uninstall(IGameEntity entity)
        {
            _disposables.Dispose();
        }
    }
}