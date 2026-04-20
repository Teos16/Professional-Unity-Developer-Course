using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    [CreateAssetMenu(
        fileName = "PresentersInstallers",
        menuName = "Zenject/PresentersInstallers"
    )]
    public sealed class PresentersInstallers : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlanetPresenter>()
                .FromComponentsInHierarchy()
                .AsCached();

            Container
                .Bind<MoneyPresenter>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<PlanetPopupPresenter>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlanetScreenInitializer>()
                .AsSingle()
                .NonLazy();
        }
    }
}