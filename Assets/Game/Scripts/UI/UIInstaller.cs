using Zenject;

namespace Game.UI
{
    //Don't modify
    public sealed class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ControlsView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<ControlsPresenter>().FromNew().AsSingle();
        }
    }
}